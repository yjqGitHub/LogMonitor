using System.ComponentModel.DataAnnotations;

namespace LogMonitor.WebManage.Models
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(50, ErrorMessage = "用户名过长")]
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Pwd { get; set; }

        /// <summary>
        /// 是否记住密码
        /// </summary>
        public bool IsRemind { get; set; }
    }
}