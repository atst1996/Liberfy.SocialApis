﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApis.Mastodon.Apis
{
    using IQuery = ICollection<KeyValuePair<string, object>>;

    public class AccountsApi : ApiBase
    {
        internal AccountsApi(MastodonApi tokens) : base(tokens) { }

        public Task<Account> Account(long accountId, IQuery query = null)
        {
            return this.Api.RestApiGetRequestAsync<Account>($"accounts/{ accountId }", query);
        }

        public Task<Account> VerifyCredentials()
        {
            return this.Api.RestApiGetRequestAsync<Account>("accounts/verify_credentials");
        }

        // Task<Account> UpdateCredentials() function is not implemented yet.

        public Task<Account[]> Followers(long accountId, IQuery query = null)
        {
            return this.Api.RestApiGetRequestAsync<Account[]>($"accounts/{ accountId }/followers", query);
        }

        public Task<Account[]> Following(long accountId, IQuery query = null)
        {
            return this.Api.RestApiGetRequestAsync<Account[]>($"accounts/{ accountId }/following", query);
        }

        public Task<Status[]> Statuses(long accountId, IQuery query = null)
        {
            return this.Api.RestApiGetRequestAsync<Status[]>($"accounts/{ accountId }/statuses", query);
        }

        public Task<Relationship> Follow(long accountId)
        {
            return this.Api.RestApiPostRequestAsync<Relationship>($"accounts/{ accountId }/follow");
        }

        public Task<Relationship> Unfollow(long accountId)
        {
            return this.Api.RestApiPostRequestAsync<Relationship>($"accounts/{ accountId }/unfollow");
        }

        public Task<Relationship> Block(long accountId)
        {
            return this.Api.RestApiPostRequestAsync<Relationship>($"accounts/{ accountId }/block");
        }

        public Task<Relationship> Unblock(long accountId)
        {
            return this.Api.RestApiPostRequestAsync<Relationship>($"accounts/{ accountId }/unblock");
        }

        public Task<Relationship> Mute(long accountId, bool? notifications)
        {
            var query = new Query();
            if (notifications.HasValue)
                query["notifications"] = notifications.Value;

            return this.Api.RestApiPostRequestAsync<Relationship>($"accounts/{ accountId }/mute", query);
        }

        public Task<Relationship> Unmute(long accountId)
        {
            return this.Api.RestApiPostRequestAsync<Relationship>($"accounts/{ accountId }/unmute");
        }

        public Task<Relationship[]> Relationships(params long[] accountIds)
        {
            var query = new Query { ["id"] = accountIds };
            return this.Api.RestApiGetRequestAsync<Relationship[]>("accounts/relationships", query);
        }

        public Task<Account[]> Search(IQuery query = null)
        {
            return this.Api.RestApiGetRequestAsync<Account[]>("accounts/search", query);
        }
    }
}
