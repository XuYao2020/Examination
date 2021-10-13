using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public Model Get()
        {
            return new Model()
            {
                title = "API返回的Json原数据",
                age = 18,
                strTime = DateTime.Now,
                content = @"JSON是一种数据格式，以这种键值对的方式，用字符串的形式表述这种复杂的C#实体对象。" +
                @"因为HTTP协议传输数据只能传输字符串，就算是上传图片音频，他也是转换为二进制流数据再上传的。" +
                @"所以当我们想把C#一个实体对象当作交互数据与前后端互相传递时，就必须把他转成字符串，JSON数据就是已经转换完成为字符串的实体对象。" +
                @"你现在看到的title，content,age,strTime都是C#中Model类的四个字段。" +
                @"这整段字符就是JSON字符串。JSON的格式就是用{}包裹这个实体对象的属性，用双引号来包裹字段和值，用：隔开字段和值，多个字段又用逗号隔开。"+
                @"将json数据复制到专门解析json格式的网站，可以更直观的查看这个JSON数据的字段和值：https://www.json.cn。"
            };
        }
        public class Model
        {
            public string title { get; set; }
            public int age { get; set; }
            public DateTime strTime { get; set; }
            public string content { get; set; }
        }
    }
}
