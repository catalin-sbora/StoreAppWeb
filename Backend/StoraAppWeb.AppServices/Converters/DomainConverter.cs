using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoraAppWeb.AppServices.Converters
{
    public abstract class DomainConverter<InfoClass, DomainClass>
    {
        public abstract InfoClass ToInfoObject(DomainClass domainObject);
        public abstract DomainClass ToDomainObject(InfoClass infoObject);        
    }
}
