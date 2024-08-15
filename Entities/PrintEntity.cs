using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PrintSerApp.Entities
{
    public class PrintEntity
    {
        [DisplayName("主键")]
        [Comment("主键")]
        [AutoGenerateColumn(Ignore = true)]
        public int Id { get; set; }

        [DisplayName("模板名称")]
        [Comment("模板名称")]
        [Required(ErrorMessage = "模板名称不能为空")]
        [AutoGenerateColumn(Order = 20, Width = 360, Align = Alignment.Center)]
        [MaxLength(50, ErrorMessage = "模板名称不能超过50个字符")]
        public string? Name { get; set; }

        [DisplayName("描述说明")]
        [Comment("描述说明")]
        [MaxLength(200, ErrorMessage = "描述说明不能超过200个字符")]
        [AutoGenerateColumn(Order = 30)]
        public string? Description { get; set; }

        //创建时间
        [DisplayName("创建时间")]
        [Comment("创建时间")]
        [AutoGenerateColumn(Order = 10, FormatString = "yyyy-MM-dd HH:mm:ss", Width = 180, Align = Alignment.Center, IsVisibleWhenAdd = false, IsVisibleWhenEdit = false)]
        public DateTime CreateTime { get; set; }
    }
}