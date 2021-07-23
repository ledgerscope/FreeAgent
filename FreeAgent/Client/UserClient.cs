using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class UserClient : ResourceClient<UserWrapper, UsersWrapper, User>
    {
        public UserClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "users";

        public override UserWrapper WrapperFromSingle(User single)
        {
            return new UserWrapper { user = single };
        }

        public override List<User> ListFromWrapper(UsersWrapper wrapper)
        {
            return wrapper.users;
        }

        public override User SingleFromWrapper(UserWrapper wrapper)
        {
            return wrapper.user;
        }

        public User Me
        {
            get { return Get("me"); }
        }
    }
}

