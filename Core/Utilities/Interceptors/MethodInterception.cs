using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        //if a class has marked as MethodInterception, 
        //it can override these methods.
        //If it overrides to OnBefore, that aspects is going to run before the method.
        public virtual void OnBefore(IInvocation invocation) { }

        //If it overrides to OnAfter, that aspects is going to run after the method. Does not matter if is succeed.
        public virtual void OnAfter(IInvocation invocation) { }

        //If it overrides to OnAfter, that aspects is going to run after if the method is succeed.
        public virtual void OnSuccess(IInvocation invocation) { }

        //If it overrides to OnAfter, that aspects is going to run after if the method is failed.
        public virtual void OnException(IInvocation invocation, System.Exception e) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSucceed = false;

            OnBefore(invocation);
            try
            {
                invocation.Proceed();
                isSucceed = true;
            }
            catch (Exception exception)
            {
                isSucceed = false;
                OnException(invocation, exception);
                throw;
            }
            finally
            {
                if (isSucceed)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);

        }
    }
}
