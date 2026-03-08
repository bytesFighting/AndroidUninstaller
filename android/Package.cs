using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUninstaller.android
{
    internal class Package
    {
        /// <summary>
        /// 预置的可卸载应用包名枚举
        /// </summary>
        public enum UninstallablePackage
        {
            /// <summary>
            /// 爱奇艺
            /// </summary>
            com_qiyi_video,

            /// <summary>
            /// 百度地图
            /// </summary>
            com_baidu_BaiduMap,

            /// <summary>
            /// 东方财富
            /// </summary>
            com_eastmoney_android_berlin,

            /// <summary>
            /// 抖音
            /// </summary>
            com_ss_android_ugc_aweme,

            /// <summary>
            /// 快手
            /// </summary>
            com_smile_gifmaker,

            /// <summary>
            /// 小米新桌面
            /// </summary>
            com_miui_newhome,

            /// <summary>
            /// 拼多多
            /// </summary>
            com_xunmeng_pinduoduo,

            /// <summary>
            /// 去哪儿旅行
            /// </summary>
            com_Qunar,

            /// <summary>
            /// 腾讯视频
            /// </summary>
            com_tencent_qqlive,

            /// <summary>
            /// 新浪微博
            /// </summary>
            com_sina_weibo,

            /// <summary>
            /// 喜马拉雅
            /// </summary>
            com_ximalaya_ting_android,

            /// <summary>
            /// 讯飞输入法小米版
            /// </summary>
            com_iflytek_inputmethod_miui,

            /// <summary>
            /// 知乎
            /// </summary>
            com_zhihu_android,

            /// <summary>
            /// QQ浏览器
            /// </summary>
            com_tencent_mtt,

            /// <summary>
            /// UC浏览器
            /// </summary>
            com_UCMobile,

            /// <summary>
            /// WPS Office
            /// </summary>
            cn_wps_moffice_eng,

            /// <summary>
            /// WPS Office小米轻量版
            /// </summary>
            cn_wps_moffice_eng_xiaomi_lite
        }

        /// <summary>
        /// 将枚举值转换为包名字符串
        /// </summary>
        /// <param name="package">可卸载应用包名枚举</param>
        /// <returns>对应的包名字符串</returns>
        public static string ToPackageName(UninstallablePackage package)
        {
            return package.ToString().Replace('_', '.');
        }

        /// <summary>
        /// 获取所有可卸载应用的包名列表
        /// </summary>
        /// <returns>包名字符串列表</returns>


        private static readonly Dictionary<UninstallablePackage, string> PackageNames = new()
        {
            { UninstallablePackage.com_qiyi_video, "爱奇艺" },
            { UninstallablePackage.com_baidu_BaiduMap, "百度地图" },
            { UninstallablePackage.com_eastmoney_android_berlin, "东方财富" },
            { UninstallablePackage.com_ss_android_ugc_aweme, "抖音" },
            { UninstallablePackage.com_smile_gifmaker, "快手" },
            { UninstallablePackage.com_miui_newhome, "小米新桌面" },
            { UninstallablePackage.com_xunmeng_pinduoduo, "拼多多" },
            { UninstallablePackage.com_Qunar, "去哪儿旅行" },
            { UninstallablePackage.com_tencent_qqlive, "腾讯视频" },
            { UninstallablePackage.com_sina_weibo, "新浪微博" },
            { UninstallablePackage.com_ximalaya_ting_android, "喜马拉雅" },
            { UninstallablePackage.com_iflytek_inputmethod_miui, "讯飞输入法小米版" },
            { UninstallablePackage.com_zhihu_android, "知乎" },
            { UninstallablePackage.com_tencent_mtt, "QQ浏览器" },
            { UninstallablePackage.com_UCMobile, "UC浏览器" },
            { UninstallablePackage.cn_wps_moffice_eng, "WPS Office" },
            { UninstallablePackage.cn_wps_moffice_eng_xiaomi_lite, "WPS Office小米轻量版" }
        };

        /// <summary>
        /// 将枚举值转换为应用名称
        /// </summary>
        /// <param name="package">可卸载应用包名枚举</param>
        /// <returns>应用名称</returns>
        public static string ToAppName(UninstallablePackage package)
        {
            return PackageNames.TryGetValue(package, out string? name) ? name ?? package.ToString() : package.ToString();
        }

        /// <summary>
        /// 将包名字符串转换为应用名称
        /// </summary>
        /// <param name="packageName">包名字符串</param>
        /// <returns>应用名称，如果不在列表中则返回包名</returns>
        public static string ToAppName(string packageName)
        {
            string enumName = packageName.Replace('.', '_');
            if (Enum.TryParse(enumName, out UninstallablePackage package))
            {
                return ToAppName(package);
            }
            return packageName;
        }

        public static string GetAppName(string packageName)
        {
            // 检测 packageName 是否在 UninstallablePackage 枚举中
            string enumName = packageName.Replace('.', '_');
            bool isDefined = Enum.IsDefined(typeof(UninstallablePackage), enumName);
            if (isDefined)
            {
                UninstallablePackage package = (UninstallablePackage)Enum.Parse(typeof(UninstallablePackage), enumName);
                return ToAppName(package);
            }
            return "";
        }
    }
}