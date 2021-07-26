using FreeAgent.Exceptions;
using FreeAgent.Extensions;
using FreeAgent.Helpers;
using FreeAgent.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public partial class FreeAgentClient
    {
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
            //_restClient.AddHandler("application/json", new JsonDeserializer());
            _restClient.AddHandler("application/json", () => new JsonDeserializer());

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
        public InvoiceClient Invoice;
        public RecurringInvoiceClient RecurringInvoice;
        public CreditNoteClient CreditNote;
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

        private void SetupClients()
        {
            Company = new CompanyClient(this);
            Contact = new ContactClient(this);
            Category = new CategoryClient(this);
            Invoice = new InvoiceClient(this);
            RecurringInvoice = new RecurringInvoiceClient(this);
            CreditNote = new CreditNoteClient(this);
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
        }

        private bool IsSuccess(HttpStatusCode code)
        {
            int val = (int)code;

            return val < 299;
        }

        private void SetAuthentication(RestRequest request)
        {
            request.AddHeader("Authorization", "Bearer " + CurrentAccessToken.access_token);
        }

#if !WINDOWS_PHONE
        internal T Execute<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response;

            SetProxy();
            //Console.WriteLine(_restClient.BuildUri(request));
            response = _restClient.Execute<T>(request);

            if (!IsSuccess(response.StatusCode))
            {
                Console.WriteLine(response.Content);
                throw new FreeAgentException(response);
            }

            if (response.Data == null)
            {
                Console.WriteLine("{0} returned null", _restClient.BuildUri(request));
            }

            return response.Data;
        }

        internal IRestResponse Execute(IRestRequest request)
        {
            IRestResponse response;

            response = _restClient.Execute(request);

            if (!IsSuccess(response.StatusCode))
            {
                throw new FreeAgentException(response);
            }

            return response;
        }
#endif

        protected void ExecuteAsync(IRestRequest request, Action<IRestResponse> success, Action<FreeAgentException> failure)
        {
#if WINDOWS_PHONE
    //check for network connection
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                //do nothing
                failure(new DropboxException
                {
                    StatusCode = System.Net.HttpStatusCode.BadGateway
                });
                return;
            }
#endif

            _restClient.ExecuteAsync(request, (response, asynchandler) =>
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    failure(new FreeAgentException(response));
                }
                else
                {
                    success(response);
                }
            });
        }

        protected void ExecuteAsync<T>(IRestRequest request, Action<T> success, Action<FreeAgentException> failure) where T : new()
        {
#if WINDOWS_PHONE
    //check for network connection
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                //do nothing
                failure(new DropboxException
                {
                    StatusCode = System.Net.HttpStatusCode.BadGateway
                });
                return;
            }
#endif

            _restClient.ExecuteAsync<T>(request, (response, asynchandler) =>
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    failure(new FreeAgentException(response));
                }
                else
                {
                    success(response.Data);
                }
            });
        }

        private Task<T> ExecuteTask<T>(IRestRequest request) where T : new()
        {
            return _restClient.ExecuteTask<T>(request);
        }

        private Task<IRestResponse> ExecuteTask(IRestRequest request)
        {
            return _restClient.ExecuteTask(request);
        }

        private void SetAuthProviders()
        {
            //if (UserLogin != null)
            //{
            //Set the OauthAuthenticator only when the UserLogin property changes
            //   _restClient.Authenticator = new OAuthAuthenticator(_restClient.BaseUrl, _apiKey, _appsecret, UserLogin.Token, UserLogin.Secret);
            //}
        }
    }
}