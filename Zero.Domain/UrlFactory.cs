﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Zero.Domain.Products;

namespace Zero.Domain
{
    public class PhotoUrlFactory
    {
        public const string PhotoSiteUrl = "http://img.zero.com/";
        //public const string PhotoSiteUrl = "http://localhost:2330/";

        /// <summary>
        /// 获取各种模式的图片地址
        /// </summary>
        /// <param name="path">图片弟子</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static string GetPhotoUrl(string path, int width, int height)
        {
            if (string.IsNullOrEmpty(path)) return string.Empty;
            path = path.Replace("http://img.zero.com/tb/", "").Replace("_100x100_0", "").Split('|')[0];
            return GetPhotoUrl(path, width, height, 0);
        }

        /// <summary>
        /// 获取各种模式的图片地址
        /// </summary>
        /// <param name="path">图片弟子</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="model">模式（0=按比例进行缩放|1=按比例缩放再按1/2进行裁剪|）</param>
        /// <returns></returns>
        public static string GetPhotoUrl(string path, int width, int height, int model)
        {
            if (path.Contains("http"))
            {
                return path;
            }

            string size = string.Format("_{0}x{1}_{2}", width, height, model);
            string name = path.Substring(path.LastIndexOf("/") + 1);
            string format = name.Substring(name.IndexOf("."));
            path = path.Substring(0, path.Length - name.Length);
            name = name.Substring(0, name.Length - format.Length);
            //return path + Zero.Core.Security.Encrypt.EncodeDES(name + size, "aaaaaaaaaa") + format;
            //return PhotoSiteUrl + "tb/" + path + HttpUtility.HtmlEncode(name + size) + format;
            return PhotoSiteUrl + "tb/" + path + name + size + format;
        }
    }

    public class ProductUrlFactory
    {
        public const string ListUrl = "/product?cateId={1}&page={2}";

        public const string DetailUrl = "/product/detail?productId={0}";
        

        public static string GetDetailUrl(int productId)
        {
            return string.Format(DetailUrl,productId);
        }

        public static string GetListUrl(int cateId)
        {
            return string.Format(ListUrl, cateId);
        }

        public static string GetListUrl(ProductSearch search)
        {
           
            return "";
        }
    }
}
