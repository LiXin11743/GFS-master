using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.Text;

namespace ZGZY.WebUI.admin.ashx
{
    /// <summary>
    /// bg_Finance 的摘要说明
    /// </summary>
    public class bg_Finance : IHttpHandler
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
                JavaScriptSerializer jsonSerialize = new JavaScriptSerializer();
                switch (action)
                {
                    case "getbutton":   //根据用户的权限获取用户点击的菜单有权限的按钮
                        string pageName = context.Request.Params["pagename"];
                        string menuCode = context.Request.Params["menucode"];   //菜单标识码
                        DataTable dt = new ZGZY.BLL.Customers().GetButtonByMenuCodeAndUserId(menuCode, user.Id);
                        string sum = ZGZY.Common.ToolbarHelper.GetToolBar(dt, pageName);
                        context.Response.Write(sum);
                        break;
                    case "add":
                        if (user != null && new ZGZY.BLL.Authority().IfAuthority("Channel", "add", user.Id))
                        {
                            Model.Finance FinanceModel = new Model.Finance();
                            FinanceModel.FinanceName = context.Request.Params["ui_Finance_FinanceName_add"];
                            FinanceModel.ChannelId = Int32.Parse(context.Request.Params["ui_Finance_ChannelID"]);
                            FinanceModel.ManagerId = 72;
                            FinanceModel.State = Int32.Parse(context.Request.Params["ui_Finance_State_add"]);
                            FinanceModel.CreateDate = DateTime.Now;
                            FinanceModel.FinanceType = Int32.Parse(context.Request.Params["ui_Finance_FinanceType_add"]);
                            FinanceModel.Remark = context.Request.Params["ui_Finance_Remark_add"];
                            FinanceModel.FinanceNum = Int32.Parse(context.Request.Params["ui_Finance_FinanceNum_add"]);
                            FinanceModel.Amount = Int32.Parse(context.Request.Params["ui_Finance_Amount_add"]);
                            int departmentId = new ZGZY.BLL.Finance().AddFinance(FinanceModel);
                            if (departmentId > 0)
                            {
                                Model.CustomerFinance cusFin = new Model.CustomerFinance();
                                cusFin.CusId = Int32.Parse(context.Request.Params["ui_Finance_CustomersID"]);
                                cusFin.FinanceId = departmentId;
                                cusFin.BeginDate = DateTime.Parse(context.Request.Params["ui_Finance_BeginDate_add"]);
                                cusFin.EndDate = DateTime.Parse(context.Request.Params["ui_Finance_EndDate_add"]);
                                new ZGZY.BLL.CustomerFinance().AddCustomerFinance(cusFin);

                                userOperateLog.OperateInfo = "添加结算";
                                userOperateLog.IfSuccess = true;
                                userOperateLog.Description = "添加成功，客户主键：" + departmentId;
                                context.Response.Write("{\"msg\":\"添加成功！\",\"success\":true}");
                            }
                            else
                            {
                                userOperateLog.OperateInfo = "添加结算";
                                userOperateLog.IfSuccess = false;
                                userOperateLog.Description = "添加失败";
                                context.Response.Write("{\"msg\":\"添加失败！\",\"success\":false}");
                            }
                        }
                        else
                        {
                            userOperateLog.OperateInfo = "添加结算";
                            userOperateLog.IfSuccess = false;
                            userOperateLog.Description = "无权限，请联系管理员";
                            context.Response.Write("{\"msg\":\"无权限，请联系管理员！\",\"success\":true}");
                        }
                        ZGZY.BLL.UserOperateLog.InsertOperateInfo(userOperateLog);
                        break;
                    case "GetChannelList":
                        List<Model.VW_GetEndDateAndBeginDateByChannelID> list = new ZGZY.BLL.Finance().GetFinanceFromCombobox();
                        context.Response.Write(jsonSerialize.Serialize(list));
                        //string strjson = GetJsonStr(list);
                        //context.Response.Write(strjson);  GetDateById
                        break;
                    case "GetCustomersList":
                        List<Model.Customers> listCus = new ZGZY.BLL.Customers().GetCustomersTbaleNoP();
                        context.Response.Write(jsonSerialize.Serialize(listCus));
                        break;
                    case "GetDateById":
                        object Id = context.Request.Params["Id"];
                        Model.VW_GetEndDateAndBeginDateByChannelID model = new ZGZY.BLL.Finance().Get_VWDate(Id);
                        context.Response.Write(jsonSerialize.Serialize(model));
                        break;
                    case "search":
                        string strWhere = "1=1";
                        string sort = context.Request.Params["sort"];  //排序列
                        string order = context.Request.Params["order"];  //排序方式 asc或者desc
                        int pageindex = int.Parse(context.Request.Params["page"]);
                        int pagesize = int.Parse(context.Request.Params["rows"]);

                        int totalCount;   //输出参数
                        string strJson = new ZGZY.BLL.Button().GetPager("VW_FinanceAndChannel", "UserName,Id,CusId,CusName, FinanceName,BeginDate,EndDate, ChannelId, ManagerId, State, CreateDate, FinanceType, Remark, Amount, FinanceNum, ChannelName, Creator, SealNameId", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
                        context.Response.Write("{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}");
                        userOperateLog.OperateInfo = "查询按钮";
                        userOperateLog.IfSuccess = true;
                        userOperateLog.Description = "查询条件：" + strWhere + " 排序：" + sort + " " + order + " 页码/每页大小：" + pageindex + " " + pagesize;
                        ZGZY.BLL.UserOperateLog.InsertOperateInfo(userOperateLog);
                        break;
                    case "edit":
                        if (user != null && new ZGZY.BLL.Authority().IfAuthority("Channel", "edit", user.Id))
                        {
                            Model.Finance financemodel = new Model.Finance();
                            financemodel.Id = Int32.Parse(context.Request.Params["ID"]);
                            financemodel.FinanceName = context.Request.Params["ui_Finance_FinanceName_edit"];
                            financemodel.ChannelId = Int32.Parse(context.Request.Params["ui_Finance_ChannelID_edit"]);
                            financemodel.State = Int32.Parse(context.Request.Params["ui_Finance_State_edit"]);
                            financemodel.FinanceType = Int32.Parse(context.Request.Params["ui_Finance_FinanceType_edit"]);
                            financemodel.FinanceNum = Int32.Parse(context.Request.Params["ui_Finance_FinanceNum_edit"]);
                            financemodel.Amount = double.Parse(context.Request.Params["ui_Finance_Amount_edit"]);
                            financemodel.Remark = context.Request.Params["ui_Finance_Remark_edit"];
                            int outputRow = new ZGZY.BLL.Finance().EditFinanceByFinanceID(financemodel);
                            Model.CustomerFinance modelCusFin = new Model.CustomerFinance();
                            modelCusFin.FinanceId = financemodel.Id;
                            modelCusFin.BeginDate = DateTime.Parse(context.Request.Params["ui_Finance_BeginDate_edit"]);
                            modelCusFin.EndDate = DateTime.Parse(context.Request.Params["ui_Finance_EndDate_edit"]);
                            modelCusFin.CusId = Int32.Parse(context.Request.Params["ui_Finance_CustomersID_edit"]);
                            outputRow += new ZGZY.BLL.CustomerFinance().EditCustomerFinanceByFinanceId(modelCusFin);
                            if (outputRow ==2)
                            {
                                userOperateLog.OperateInfo = "修改结算";
                                userOperateLog.IfSuccess = true;
                                userOperateLog.Description = "修改成功，客户主键：" + outputRow;
                                context.Response.Write("{\"msg\":\"修改成功！\",\"success\":true}");
                            }
                            else
                            {
                                userOperateLog.OperateInfo = "修改结算";
                                userOperateLog.IfSuccess = false;
                                userOperateLog.Description = "修改失败";
                                context.Response.Write("{\"msg\":\"修改失败！\",\"success\":false}");
                            }
                        }
                        else
                        {
                            userOperateLog.OperateInfo = "修改结算";
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
                            if (new ZGZY.BLL.Finance().DeleteFinanceByFinanceID(departmentIds) == 1)
                            {
                                userOperateLog.OperateInfo = "删除结算";
                                userOperateLog.IfSuccess = true;
                                userOperateLog.Description = "删除成功，结算主键：" + departmentIds;
                                context.Response.Write("{\"msg\":\"删除成功！\",\"success\":true}");
                            }
                            else
                            {
                                userOperateLog.OperateInfo = "删除结算";
                                userOperateLog.IfSuccess = false;
                                userOperateLog.Description = "删除失败，客户主键：" + departmentIds;
                                context.Response.Write("{\"msg\":\"删除失败！\",\"success\":false}");
                            }
                        }
                        else
                        {
                            userOperateLog.OperateInfo = "删除结算";
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
        public string GetJsonStr(Model.VW_GetEndDateAndBeginDateByChannelID model)
        {
            StringBuilder strJson = new StringBuilder();
            if (model != null)
            {
                strJson.Append("{[");
                strJson.Append("\"Id\":" + model.Id + ",\"GetBeginDate\":" + model.GetBeginDate.ToString() + ",\"GetEndDate\":" + model.GetEndDate.ToString() + ",\"ChannelName\":" + model.ChannelName);
                strJson.Append("]}");
            }
            else
            {
                strJson.Append("{[\"Id\":\"-1\",\"ChannelName\":\"毫无数据\"]}");
            }
            return strJson.ToString();

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