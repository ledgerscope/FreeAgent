using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class ProjectClient : ResourceClient<ProjectWrapper, ProjectsWrapper, Project>
    {
        public ProjectClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "projects";

        public override ProjectWrapper WrapperFromSingle(Project single)
        {
            return new ProjectWrapper { project = single };
        }

        public override List<Project> ListFromWrapper(ProjectsWrapper wrapper)
        {
            return wrapper.projects;
        }

        public override Project SingleFromWrapper(ProjectWrapper wrapper)
        {
            return wrapper.project;
        }

        public override void CustomizeAllRequest(RestRequest request)
        {
            request.AddParameter("view", "active", ParameterType.GetOrPost);
        }
    }
}

