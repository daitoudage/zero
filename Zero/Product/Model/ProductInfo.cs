﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace Zero.Product.Model
{
    [TableName("Product")]
    [PrimaryKey("ProductId")]
    /// <summary>
    /// 商品基本信息
    /// </summary>
    public partial class ProductInfo
    {
        /// <summary>
        /// 商品自增ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 类别编号
        /// </summary>
        public int CateId { get; set; }

        /// <summary>
        /// 商品类型(全新，二手，拍卖)
        /// </summary>
        public int ProductType { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品副标题
        /// </summary>
        public string SubName { get; set; }

        /// <summary>
        /// 商品编码(1020122)
        /// </summary>
        public string Zsc { get; set; }

        /// <summary>
        /// 一口价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 总库存
        /// </summary>
        public decimal Amount { get; set; }

        [Ignore]
        /// <summary>
        /// 库存列表
        /// </summary>
        public List<SkuInfo> SkuList { get; set; }

        [Ignore]
        /// <summary>
        /// 图片列表
        /// </summary>
        public List<ProductPhotoInfo> PhotoList { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 默认图片
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 体积
        /// </summary>
        public decimal Bulk { get; set; }

        /// <summary>
        /// 所选的属性
        /// kid:vid:key:value|1:1:颜色:白色|
        /// </summary>
        public string Attr { get; set; }

        [Ignore]
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 运费承担方式（Buyer|Seller）
        /// </summary>
        public string FreightPayer { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 自定义分类
        /// </summary>
        public string Groups { get; set; }

        /// <summary>
        /// 是否有发票
        /// </summary>
        public bool HasInvoice { get; set; }

        /// <summary>
        /// 是否保修
        /// </summary>
        public bool HasWarranty { get; set; }

        /// <summary>
        /// 是否推荐橱窗
        /// </summary>
        public bool HasShowcase { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public decimal Score { get; set; }

        /// <summary>
        /// 排列序号
        /// </summary>
        public int Oid { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        [Ignore]
        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailUrl { get; set; }

        /// <summary>
        /// 开始时间（有效期限）
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间（有效期限）
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
