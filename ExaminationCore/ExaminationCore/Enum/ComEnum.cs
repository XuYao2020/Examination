using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationCore
{
    public static class ComEnum
    {
        public enum ReturnCode
        {
            [Description("操作成功")]
            A_操作成功 = 0,
            [Description("操作失败")]
            A_操作失败 = 1,
            [Description("参数异常")]
            A_参数异常 = 2,
            [Description("未找到对象")]
            A_未找到对象 = 3,
            [Description("必填字段为空")]
            A_必填字段为空 = 4,
            [Description("已有同名数据,请避免数据重复")]
            A_已有同名参数 = 5,
            [Description("条件判断未通过，刷新重试")]
            A_条件判断未通过 = 6,
            [Description("当前对象为失效或者禁用状态")]
            A_当前对象失效 = 7,
            [Description("邮箱已存在")]
            A_邮箱已存在 = 8
        }
        public static ReturnJsonR JsonR(this ReturnCode option,string Message="",object Body=null)
        {
            return new ReturnJsonR()
            {
                code = option.GetHashCode(),
                message = string.IsNullOrEmpty(Message) ? option.ToString() : Message,
                body = Body
            };
        }
        public class ReturnJsonR
        {
            public int code { get; set; }
            public string message { get; set; }
            public object body { get; set; }
        }
    }
}
