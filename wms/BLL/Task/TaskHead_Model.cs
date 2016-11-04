using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Task
{
    public class TaskHead_Model
    {
        public List<Task_Model> lstTaskInfo { get; set; }

        public string Status { get; set; } //状态 S成功 E 失败

        public string Message { get; set; } //失败消息

        public TaskDetails_Model taskDetailModel { get; set; }
    }
}
