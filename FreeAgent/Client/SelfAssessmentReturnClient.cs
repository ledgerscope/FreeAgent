using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class SelfAssessmentReturnClient : ResourceClient<SelfAssessmentReturnWrapper, SelfAssessmentReturnsWrapper, SelfAssessmentReturn>
    {
        public SelfAssessmentReturnClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "self_assessment_returns";

        public override SelfAssessmentReturnWrapper WrapperFromSingle(SelfAssessmentReturn single)
        {
            return new SelfAssessmentReturnWrapper { self_assessment_return = single };
        }

        public override List<SelfAssessmentReturn> ListFromWrapper(SelfAssessmentReturnsWrapper wrapper)
        {
            return wrapper.self_assessment_returns;
        }

        public override SelfAssessmentReturn SingleFromWrapper(SelfAssessmentReturnWrapper wrapper)
        {
            return wrapper.self_assessment_return;
        }
    }
}

