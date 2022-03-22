using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Core.Config
{
    public class JwtConfig
    {
        public string Issuer { get; set; }
        public int LifeMinutes { get; set; }
        public int RefreshMinutes { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public Func<string> JtiGenerator => () => Guid.NewGuid().ToString();
    }
}
