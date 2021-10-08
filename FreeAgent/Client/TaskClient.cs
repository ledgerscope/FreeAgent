using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class TaskClient : ResourceClient<TaskWrapper, TasksWrapper, Task>
    {
        public TaskClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "tasks";

        public override TaskWrapper WrapperFromSingle(Task single)
        {
            return new TaskWrapper { task = single };
        }

        public override List<Task> ListFromWrapper(TasksWrapper wrapper)
        {
            return wrapper.tasks;
        }

        public override Task SingleFromWrapper(TaskWrapper wrapper)
        {
            return wrapper.task;
        }

        //public List<Task> AllForProject(string project)
        //{
        //    return All((request) => request.AddParameter("project", project, ParameterType.GetOrPost));
        //}

        //public Task Put(Task item, string project)
        //{
        //    var request = CreatePutRequest(item);
        //    request.Resource += "?project={project}";

        //    request.AddParameter("project", project, ParameterType.UrlSegment);

        //    var response = Client.Execute<TaskWrapper>(request);

        //    if (response != null) return SingleFromWrapper(response);

        //    return null;
        //}
    }
}

