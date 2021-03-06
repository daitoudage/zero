﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

using Zero.Core.Web;
using Zero.Core.Pattern;
using Zero.Domain.Cates;
using Zero.Service.Cates;
namespace Zero.Mvc.Manage.Controllers.Cates
{
    /// <summary>
    /// 属性管理
    /// </summary>
    public partial class CateAttrController : BaseController
    {
        ICateService<Cate> _cateService;
        ICateAttrService _cateAttrService;
        IAttrValueService _attrValueService;

        public CateAttrController(ICateService<Cate> cateService,
            ICateAttrService cateAttrService,
            IAttrValueService attrValueService)
        {
            _cateService = cateService;
            _cateAttrService = cateAttrService;
            _attrValueService = attrValueService;
        }

        public ActionResult AttrValueList()
        {
            int attrId = RequestHelper.QueryInt("attrId");

            List<AttrValue> productList = _attrValueService.GetList(attrId);

            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CateAttrList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");
            int cateId = RequestHelper.QueryInt("cateId");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            CateAttrSearch search = new CateAttrSearch();
            search.CateId = cateId;
            IPage<CateAttr> productPage = _cateAttrService.GetList(search, pageIndex, pageSize);

            return Json(productPage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CateAttrIndex()
        {
            return View();
        }

        public ActionResult CateAttrAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CateAttrAdd(CateAttr cateAttr)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                resultInfo = _cateAttrService.Add(cateAttr);
            }

            return Json(resultInfo);
        }

        public ActionResult CateAttrEdit()
        {
            int cateAttrId = RequestHelper.QueryInt("cateAttrId");
            CateAttr cateAttr = _cateAttrService.GetById(cateAttrId);
            return View(cateAttr);
        }

        [HttpPost]
        public ActionResult CateAttrEdit(CateAttr cateAttr)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                CateAttr oldCateAttr = _cateAttrService.GetById(cateAttr.CAID);
                oldCateAttr.CateId = cateAttr.CateId;
                oldCateAttr.AttrId = cateAttr.AttrId;
                oldCateAttr.AttrValue = cateAttr.AttrValue;
                oldCateAttr.Type = cateAttr.Type;
                oldCateAttr.IsMust = cateAttr.IsMust;
                oldCateAttr.IsKey = cateAttr.IsKey;
                oldCateAttr.IsSale = cateAttr.IsSale;
                oldCateAttr.IsAllowAlias = cateAttr.IsAllowAlias;
                
                oldCateAttr.Oid = cateAttr.Oid;

                resultInfo = _cateAttrService.Edit(oldCateAttr);
            }

            return Json(resultInfo);
        }

        [HttpPost]
        public ActionResult CateAttrOperate()
        {
            ResultInfo resultInfo;

            string action = RequestHelper.All("action").ToLower();
            string ids = RequestHelper.All("ids").ToLower();

            if (action == "" || ids == "")
            {
                resultInfo = new ResultInfo((int)ResultStatus.Error, "未选择任何操作或未选择任何操作项！");
                return Json(resultInfo);
            }

            switch (action)
            {
                case "delete":
                    _cateAttrService.Delete(ids);
                    break;
            }

            return Json(new ResultInfo("操作成功"));
        }
    }
}
