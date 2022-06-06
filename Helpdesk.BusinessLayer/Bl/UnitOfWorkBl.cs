using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpdesk.Core.Interfaces.InterfaceBl;

namespace Helpdesk.BusinessLayer.Bl
{
    public class UnitOfWorkBl: IUnitOfWorkBl
    {
        public UnitOfWorkBl(IUser user)
        {
            this.User = user;
        }

        public IUser User {get;}
    }
}