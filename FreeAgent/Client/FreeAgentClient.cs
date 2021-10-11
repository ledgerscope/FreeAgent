using ComposableAsync;
using FreeAgent.Exceptions;
using FreeAgent.Extensions;
using FreeAgent.Helpers;
using FreeAgent.Models;
using RateLimiter;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public partial class FreeAgentClient
    {
        // Even though the API says we can do 120 requests in 60 seconds, we configure the rate limiter to do 119 requests every 61 seconds (just to be safe)
        private readonly TimeLimiter _timeConstraint = TimeLimiter.GetFromMaxCountByInterval(119, TimeSpan.FromSeconds(61));

        private readonly Uri _apiBaseUrl = new Uri("https://api.freeagent.com");
        private readonly Uri _apiSandboxBaseUrl = new Uri("https://api.sandbox.freeagent.com");

        public const string Version = "2";

        public static WebProxy Proxy = null;

        /// <summary>
        /// To use Dropbox API in sandbox mode (app folder access) set to true
        /// </summary>
        private static bool _useSandbox = false;

        public static bool UseSandbox { get { return _useSandbox; } set { _useSandbox = value; } }

        private readonly string _apiKey;
        private readonly string _appsecret;

        private RestClient _restClient;
        private AccessToken _currentAccessToken = null;
        private RequestHelper _requestHelper;

        public RequestHelper Helper => _requestHelper;

        public AccessToken CurrentAccessToken
        {
            get { return _currentAccessToken; }
            set
            {
                _currentAccessToken = value;
                if (_requestHelper != null)
                {
                    _requestHelper.CurrentAccessToken = _currentAccessToken;
                }
            }
        }

        /// <summary>
        /// Gets the directory root for the requests (full or sandbox mode)
        /// </summary>
        private Uri BaseUrl
        {
            get { return UseSandbox ? _apiSandboxBaseUrl : _apiBaseUrl; }
        }

        /// <summary>
        /// Default Constructor for the DropboxClient
        /// </summary>
        /// <param name="apiKey">The Api Key to use for the Dropbox Requests</param>
        /// <param name="appSecret">The Api Secret to use for the Dropbox Requests</param>
        public FreeAgentClient(string apiKey, string appSecret)
        {
            _apiKey = apiKey;
            _appsecret = appSecret;

            LoadClient();
        }

        /// <summary>
        /// Creates an instance of the DropNetClient given an API Key/Secret and a User Token/Secret
        /// </summary>
        /// <param name="apiKey">The Api Key to use for the Dropbox Requests</param>
        /// <param name="appSecret">The Api Secret to use for the Dropbox Requests</param>
        public FreeAgentClient(string apiKey, string appSecret, AccessToken savedToken)
        {
            _apiKey = apiKey;
            _appsecret = appSecret;
            CurrentAccessToken = savedToken;

            LoadClient();
        }

        private void LoadClient()
        {
            _restClient = new RestClient(BaseUrl);
            _restClient.ClearHandlers();

            // Remark 1: Will take Newtonsoft.Json.JsonPropertyAttribute into account upon deserializing (See Note.NoteContent or Period.PayrollPeriod)
            // Remark 2: For deserialization to work properly, you must either put a JsonProperty attribute on every entity Wrapper property
            //           or name the Wrapper property accordingly.
            //           For example (CreditNoteWrapper / CreditNotesWrapper):
            //              a) Either name the props as credit_note / credit_notes or
            //              b) Mark the props with a [JsonProperty("credit_note")] / [JsonProperty("credit_notes")] attributes
            //                 if they have names different then credit_note / credit_notes, like creditNote / creditNotes)
            _restClient.UseNewtonsoftJson();

            _requestHelper = new RequestHelper(Version)
            {
                ApiKey = _apiKey,
                ApiSecret = _appsecret
            };

            SetProxy();

            //Default to full access
            //UseSandbox = false;
            SetupClients();
        }

        public void SetProxy()
        {
            _restClient.Proxy = Proxy;
        }

        /// <summary>
        /// Helper Method to Build up the Url to authorize a Token/Secret
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns>Authorize Url</returns>
        public string BuildAuthorizeUrl(string callback = null, string state = null)
        {
            var redirectUriParamAndValue = string.IsNullOrEmpty(callback)
                ? string.Empty
                : $"&redirect_uri={callback.UrlEncode()}";

            var stateParamAndValue = string.IsNullOrEmpty(state)
                ? string.Empty
                : $"&state={state}";

            //return $"{BaseUrl}/v{Version}/approve_app?response_type=code&client_id={_apiKey}{stateParamAndValue}{redirectUriParamAndValue}";
            return $"{BaseUrl}/v{Version}/approve_app?response_type=code&client_id={_apiKey}{stateParamAndValue}";
        }

        public string ExtractCodeFromUrl(string url)
        {
            //url will contain code=.... in the parameters

            Uri uri = new Uri(url);
            string query = uri.Query;
            if (string.IsNullOrEmpty(query) || !query.Contains("code="))
            {
                return "";
            }

            var elements = query.ParseQueryString();

            if (elements.ContainsKey("code"))
                return elements["code"];

            return "";
        }

        public CompanyClient Company;
        public ContactClient Contact;
        public CategoryClient Category;
        public CapitalAssetClient CapitalAsset;
        public CapitalAssetTypeClient CapitalAssetType;
        public InvoiceClient Invoice;
        public RecurringInvoiceClient RecurringInvoice;
        public CreditNoteClient CreditNote;
        public CreditNoteReconciliationClient CreditNoteReconciliation;
        public EstimateClient Estimate;
        public BillClient Bill;
        public ExpenseClient Expense;
        public BankAccountClient BankAccount;
        public BankTransactionClient BankTransaction;
        public BankTransactionExplanationClient BankTransactionExplanation;
        public JournalSetClient JournalSet;
        public AccountingClient Accounting;
        public PriceListItemClient PriceListItem;
        public NoteClient Note;
        public StockItemClient StockItem;
        public TaskClient Task;
        public ProjectClient Project;
        public TimeslipClient Timeslip;
        public SalesTaxPeriodClient SalesTaxPeriod;
        public CISBandClient CISBand;
        public UserClient User;
        public EmailAddressClient EmailAddress;
        public PayrollClient Payroll;

        private void SetupClients()
        {
            Company = new CompanyClient(this);
            Contact = new ContactClient(this);
            Category = new CategoryClient(this);
            CapitalAsset = new CapitalAssetClient(this);
            CapitalAssetType = new CapitalAssetTypeClient(this);
            Invoice = new InvoiceClient(this);
            RecurringInvoice = new RecurringInvoiceClient(this);
            CreditNote = new CreditNoteClient(this);
            CreditNoteReconciliation = new CreditNoteReconciliationClient(this);
            Estimate = new EstimateClient(this);
            Bill = new BillClient(this);
            Expense = new ExpenseClient(this);
            BankAccount = new BankAccountClient(this);
            BankTransaction = new BankTransactionClient(this);
            BankTransactionExplanation = new BankTransactionExplanationClient(this);
            JournalSet = new JournalSetClient(this);
            Accounting = new AccountingClient(this);
            PriceListItem = new PriceListItemClient(this);
            Note = new NoteClient(this);
            StockItem = new StockItemClient(this);
            Task = new TaskClient(this);
            Project = new ProjectClient(this);
            Timeslip = new TimeslipClient(this);
            SalesTaxPeriod = new SalesTaxPeriodClient(this);
            CISBand = new CISBandClient(this);
            User = new UserClient(this);
            EmailAddress = new EmailAddressClient(this);
            Payroll = new PayrollClient(this);
        }

        private bool IsSuccess(HttpStatusCode code)
        {
            int val = (int)code;

            return val < 299;
        }

        internal async Task<T> Execute<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response;

            SetProxy();
            //Console.WriteLine(_restClient.BuildUri(request));

            await _timeConstraint;

            response = await _restClient.ExecuteAsync<T>(request);

            if (!IsSuccess(response.StatusCode))
            {
                //Console.WriteLine(response.Content);
                throw new FreeAgentException(response, typeof(T).Name);
            }

            if (response.Data == null)
            {
                //Console.WriteLine("{0} returned null", _restClient.BuildUri(request));
                throw new FreeAgentException(response, typeof(T).Name, response.ErrorException);
            }

            return response.Data;
        }

        internal async Task<IRestResponse> Execute(IRestRequest request)
        {
            await _timeConstraint;

            IRestResponse response = await _restClient.ExecuteAsync(request);

            if (!IsSuccess(response.StatusCode))
            {
                throw new FreeAgentException(response, innerException: response.ErrorException);
            }

            return response;
        }
    }
}