using System;

namespace AutoGlass.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string msg) : base(msg) { }

        public static void LaunchWhen(bool ruleInvalid, string msg)
        {
            if(ruleInvalid)
                throw new DomainException(msg);
        }
    }
}
