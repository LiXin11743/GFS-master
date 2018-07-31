using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace ZGZY.WebUI.admin.ashx
{
    /// <summary>
    /// bg_Channel 的摘要说明
    /// </summary>
    public class bg_Channel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "application/json";
            string action = context.Request.Params["action"];
            ZGZY.Model.UserOperateLog userOperateLog = null;   //操作日志对象
            try
            {
                ZGZY.Model.User user = ZGZY.Common.UserHelper.GetUser(context);   //获取cookie里的用户对象
                userOperateLog = new Model.UserOperateLog();
                userOperateLog.UserIp = context.Request.UserHostAddress;
                userOperateLog.UserName = user.UserId;
                 
                switch (action)
                {
                    case "getbutton":   //根据用户的权限获取用户点击的菜单有权限的按钮
                        string pageName = context.Request.Params["pagename"];
                        string menuCode = context.Request.Params["menucode"];   //菜单标识码
                        DataTable dt = new ZGZY.BLL.Customers().GetButtonByMenuCodeAndUserId(menuCode, user.Id);
                        string sum=ZGZY.Common.ToolbarHelper.GetToolBar(dt, pageName);
                        context.Response.Write(sum);
                        break;
                    case "add":
                        if (user != null && new ZGZY.BLL.Authority().IfAuthority("Channel", "add", user.Id))
                        {
                            ZGZY.Model.Channel channelAdd = new Model.Channel();
                            channelAdd.ChannelName = context.Request.Params["ui_Channel_ChannelName_add"];
                            channelAdd.Creator = context.Request.Params["ui_Channel_Creator_add"];
                            channelAdd.BeginDate = DateTime.Parse(context.Request.Params["ui_Channel_BeginDate_add"]);
                            channelAdd.EndDate =DateTime.Parse(context.Request.Params["ui_Channel_EndDate_add"]);
                            channelAdd.CreateDate = DateTime.Now;
                            channelAdd.SealNameId = 72;

           

                            int departmentId = new ZGZY.BLL.Channel().AddChannel(channelAdd);
                            if (departmentId > 0)
                            {
                                userOperateLog.OperateInfo = "添加引用";
                                userOperateLog.IfSuccess = true;
                                userOperateLog.Description = "添加成功，客户主键：" + departmentId;
                                context.Response.Write("{\"msg\":\"添加成功！\",\"success\":true}");
                            }
                            else
                            {
                                userOperateLog.OperateInfo = "添加引用";
                                userOperateLog.IfSuccess = false;
                                userOperateLog.Description = "添加失败";
                                context.Response.Write("{\"msg\":\"添加失败！\",\"success\":false}");
                            }
                        }
                        else
                        {
                            userOperateLog.OperateInfo = "添加引用";
                            userOperateLog.IfSuccess = false;
                            userOperateLog.Description = "无权限，请联系管理员";
                            context.Response.Write("{\"msg\":\"无权限，请联系管理员！\",\"success\":true}");
                        }
                        ZGZY.BLL.UserOperateLog.InsertOperateInfo(userOperateLog);
                        break;
                    case "search":
                        string strWhere = "1=1";
                        string sort = context.Request.Params["sort"];  //排序列
                        string order = context.Request.Params["order"];  //排序方式 asc或者desc
                        int pageindex = int.Parse(context.Request.Params["page"]);
                        int pagesize = int.Parse(context.Request.Params["rows"]);

                        int totalCount;   //输出参数
                        string strJson = new ZGZY.BLL.Button().GetPager("Channel", "Id, ChannelName, CreateDate, Creator, SealNameId, BeginDate, EndDate", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
                        context.Response.Write("{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}");
                        userOperateLog.OperateInfo = "查询按钮";
                        userOperateLog.IfSuccess = true;
                        userOperateLog.Description = "查询条件：" + strWhere + " 排序：" + sort + " " + order + " 页码/每页大小：" + pageindex + " " + pagesize;
                        ZGZY.BLL.UserOperateLog.InsertOperateInfo(userOperateLog);
                        break;
                    case "edit":
                        if (user != null && new ZGZY.BLL.Authority().IfAuthority("Channel", "edit", user.Id))
                        {
                            ZGZY.Model.Channel channelAdd = new Model.Channel();
                            channelAdd.Id = Int32.Parse(context.Request.Params["id"]);
                            channelAdd.ChannelName = context.Request.Params["ui_Channel_ChannelName_edit"];
                            channelAdd.Creator = context.Request.Params["ui_Channel_Creator_edit"];
                            channelAdd.BeginDate = DateTime.Parse(context.Request.Params["ui_Channel_BeginDate_edit"]);
                            channelAdd.EndDate = DateTime.Parse(context.Request.Params["ui_Channel_EndDate_edit"]);

                            int outputRow = new ZGZY.BLL.Channel().EditChannelById(channelAdd);
                            if (outputRow > 0)
                            {
                                userOperateLog.OperateInfo = "修改引用";
                                userOperateLog.IfSuccess = true;
                                userOperateLog.Description = "修改成功，客户主键：" + outputRow;
                                context.Response.Write("{\"msg\":\"修改成功！\",\"success\":true}");
                            }
                            else
                            {
                                userOperateLog.OperateInfo = "修改引用";
                                userOperateLog.IfSuccess = false;
                                userOperateLog.Description = "修改失败";
                                context.Response.Write("{\"msg\":\"修改失败！\",\"success\":false}");
                            }
                        }
                        else
                        {
                            userOperateLog.OperateInfo = "修改引用";
                            userOperateLog.IfSuccess = false;
                            userOperateLog.Description = "无权限，请联系管理员";
                            context.Response.Write("{\"msg\":\"无权限，请联系管理员！\",\"success\":true}");
                        }
                        ZGZY.BLL.UserOperateLog.InsertOperateInfo(userOperateLog);
                        break;
                    case "delete":
                        if (user != null && new ZGZY.BLL.Authority().IfAuthority("Channel", "delete", user.Id))
                        {
                            object departmentIds = context.Request.Params["id"];
                            if (new ZGZY.BLL.Channel().DeleteChannelById(departmentIds) == 1)
                            {
                                userOperateLog.OperateInfo = "删除引用";
                                userOperateLog.IfSuccess = true;
                                userOperateLog.Description = "删除成功，引用主键：" + departmentIds;
                                context.Response.Write("{\"msg\":\"删除成功！\",\"success\":true}");
                            }
                            else
                            {
                                userOperateLog.OperateInfo = "删除引用";
                                userOperateLog.IfSuccess = false;
                                userOperateLog.Description = "删除失败，客户主键：" + departmentIds;
                                context.Response.Write("{\"msg\":\"删除失败！\",\"success\":false}");
                            }
                        }
                        else
                        {
                            userOperateLog.OperateInfo = "删除引用";
                            userOperateLog.IfSuccess = false;
                            userOperateLog.Description = "无权限，请联系管理员";
                            context.Response.Write("{\"msg\":\"无权限，请联系管理员！\",\"success\":false}");
                        }
                        ZGZY.BLL.UserOperateLog.InsertOperateInfo(userOperateLog);
                        break;
                    default:
                        context.Response.Write("{\"result\":\"参数错误！\",\"success\":false}");
                        break;
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"msg\":\"" + ZGZY.Common.JsonHelper.StringFilter(ex.Message) + "\",\"success\":false}");
                userOperateLog.OperateInfo = "菜单功能异常";
                userOperateLog.IfSuccess = false;
                userOperateLog.Description = ZGZY.Common.JsonHelper.StringFilter(ex.Message);
                ZGZY.BLL.UserOperateLog.InsertOperateInfo(userOperateLog);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}