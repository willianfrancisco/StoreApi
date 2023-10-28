using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain.Validations
{
    public class DomainEntitiesValidation : Exception
    {
        public DomainEntitiesValidation(string erro) : base(erro){}
        public static void When(bool hasError, string erro)
        {
            if(hasError)
                throw new DomainEntitiesValidation(erro);
        }
    }
}