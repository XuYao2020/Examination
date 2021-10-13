using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ExaminationCore.ComEnum;

namespace ExaminationCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Util.NoLogin]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 登录s
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnJsonR UserLogin()
        {
            var Email = HttpContext.Request.Form["Email"];
            var Pwd = HttpContext.Request.Form["Pwd"];
            dynamic IsAuto = HttpContext.Request.Form["IsAuto"];
            try
            {
                var Model = DBhelper.get($"select * from StudentUser where Email='{Email}' and Pwd='{MD5Encrypt.GetMD5(Pwd)}'");
                if (Model.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(IsAuto))
                    {
                        CookieOptions option = new CookieOptions();
                        option.Expires = DateTime.Now.AddDays(7);
                        HttpContext.Response.Cookies.Append("UserId", MD5Encrypt.GetMD5(Model.Rows[0]["Id"].ToString()), option);
                    }
                    else
                    {
                        HttpContext.Response.Cookies.Append("UserId", MD5Encrypt.GetMD5(Model.Rows[0]["Id"].ToString()));
                    }
                    return ReturnCode.A_操作成功.JsonR();
                }
                else
                {
                    return ReturnCode.A_未找到对象.JsonR("请检查用户名和密码");
                }
            }
            catch (Exception e)
            {
                return ReturnCode.A_操作失败.JsonR(e.Message);
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReturnJsonR list()
        {
            return ReturnCode.A_操作成功.JsonR("测试拦截器");
        }
    }
}
