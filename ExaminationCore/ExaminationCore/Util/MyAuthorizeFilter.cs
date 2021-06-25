using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ExaminationCore.ComEnum;

namespace ExaminationCore.Util
{
    //用于处理不需要验证的业务
    public class NoLoginAttribute : ActionFilterAttribute { }
    public class MyAuthorizeFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 请求开始前调用
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 判断是否加上了不需要拦截111
            var IsAllowAnonymous = context.Filters.Any(item => item is NoLoginAttribute);
            if (!IsAllowAnonymous)
            {
                var UId = context.HttpContext.Request.Cookies["UserId"];
                if (string.IsNullOrEmpty(UId))
                {
                    context.Result = new ObjectResult(ComEnum.ReturnCode.A_操作失败.JsonR("未登录，请登陆后重试"));
                }
            }
        }
    }
}
