using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ultra.Surface.Enums
{
    /// <summary>
    /// 系统管理员帐号
    /// </summary>
    public class SysManageAccount
    {
        public static string 帐号 = "admin";
    }

    /// <summary>
    /// 订单交易状态
    /// </summary>
    public class TaoBaoStatus
    {
        //订单交易状态
        public static string 没有创建支付宝交易 = "TRADE_NO_CREATE_PAY";
        public static string 等待买家付款 = "WAIT_BUYER_PAY";
        public static string 等待卖家发货_买家已付款 = "WAIT_SELLER_SEND_GOODS";
        public static string 等待买家确认收货_卖家已发货 = "WAIT_BUYER_CONFIRM_GOODS";
        public static string 买家已签收_货到付款专用 = "TRADE_BUYER_SIGNED";
        public static string 交易成功 = "TRADE_FINISHED";
        public static string 交易关闭 = "TRADE_CLOSED";
        public static string 交易被淘宝关闭 = "TRADE_CLOSED_BY_TAOBAO";



        //退款单状态
        public static string 买家已经申请退款_等待卖家同意 = "WAIT_SELLER_AGREE";
        public static string 卖家已经同意退款_等待买家退货 = "WAIT_BUYER_RETURN_GOODS";
        public static string 买家已经退货_等待卖家确认收货 = "WAIT_SELLER_CONFIRM_GOODS";
        public static string 卖家拒绝退款 = "SELLER_REFUSE_BUYER";
        public static string 退款关闭 = "CLOSED";
        public static string 退款成功 = "SUCCESS";
    }

    #region [运费类型]
    /// <summary>
    /// 运费类型数据
    /// </summary>
    public class PostFeeType
    {
        public PostFeeType()
        {
            PostType = new List<PostFeeClass>() 
            {
                new PostFeeClass("到付",1),
                new PostFeeClass("现付",2)
            };
        }
        public List<PostFeeClass> PostType { get; set; }
    }

    /// <summary>
    /// 运费类型实体
    /// </summary>
    public class PostFeeClass
    {
        public PostFeeClass() { }
        public PostFeeClass(string name, int value)
        {
            _name = name;
            _value = value;
        }
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        private int _value;
        public int Value { get { return _value; } set { _value = value; } }
    }
    #endregion

    /// <summary>
    /// 交易类型
    /// </summary>
    public class TaoBaoType
    {
        public static string 一口价 = "fixed";
        public static string 拍卖 = "auction";
    }

    /// <summary>
    /// 权限控件类型
    /// </summary>
    public enum RoleType
    {
        Button = 1,
        GridView = 2,
        Text = 3,
        Form = 4
    }

    /// <summary>
    /// 到付类型、三包类型
    /// </summary>
    public enum ServiceType
    {
        /// <summary>
        /// 到付
        /// </summary>
        ToPay = 1,
        /// <summary>
        /// 现付
        /// </summary>
        NowPay = 2
    }

    /// <summary>
    /// 数据库操作返回值类型
    /// </summary>
    public enum ReturnType
    {
        Exists = 0,
        Success = 1,
        Fail = 2,
        None = 3
    }

    /// <summary>
    /// 下载失败类型
    /// </summary>
    public enum DownloadFailType
    {
        Trade = 1,
        Item = 2
    }

    /// <summary>
    /// 下载失败原因
    /// </summary>
    public enum DownloadFailReason
    {
        系统错误 = 1,
        解析错误 = 2
    }

    /// <summary>
    /// 订单类型
    /// </summary>
    public enum TradeType
    {
        TaoBao = 1,
        JingDong = 2,
        System = 3
    }

    /// <summary>
    /// 页面当前操作状态
    /// </summary>
    public enum Operation
    {
        View = 0,
        AddNew = 1,
        Modify = 2,
        Find = 3
    }

    /// <summary>
    /// 采购单新建或修改类型
    /// </summary>
    public enum PurchaseType
    {
        Create = 1,
        Modify = 2
    }

    /// <summary>
    /// 库存调整单状态,该枚举类型与数据库code表同步更新
    /// </summary>
    public enum AdjustStatus
    {
        New = 0,
        Closed = 9
    }

    /// <summary>
    /// 采购单状态,该枚举类型与数据库code表同步更新
    /// </summary>
    public enum PurchaseOrderStatus
    {
        New = 0,
        Receiving = 5,
        Closed = 9
    }

    /// <summary>
    /// 采购单明细状态,该枚举类型与数据库code表同步更新
    /// </summary>
    public enum PurchaseDetailStatus
    {
        New = 0,
        Receiving = 5,
        Closed = 9
    }

    /// <summary>
    /// 数据库操作类型
    /// </summary>
    public enum SqlOperation
    {
        Add = 1,
        Modify = 2,
        Delete = 3
    }

    /// <summary>
    /// 入库单入库状态
    /// </summary>
    public enum IsInStock
    {
        未入库 = 0,
        已入库 = 1
    }

    /// <summary>
    /// 入库单明细状态,该枚举类型与数据库code表同步更新
    /// </summary>
    public enum ISOrderStatus
    {
        New = 0,
        Closed = 9
    }

    /// <summary>
    /// 借出单状态,该枚举类型与数据库code表同步更新
    /// </summary>
    public enum LendOrderStatus
    {
        New = 0,
        Submit = 1,
        Printed = 3,
        Returning = 6,
        Closed = 9
    }

    /// <summary>
    /// 借出单明细状态,该枚举类型与数据库code表同步更新
    /// </summary>
    public enum LendDetailStatus
    {
        New = 0,
        Returning = 5,
        Closed = 9
    }

    /// <summary>
    /// 变更单状态,该枚举类型与数据库code表同步更新
    /// </summary>
    public enum AlterTradeStatus
    {
        New = 0,

        /// <summary>
        /// 待处理
        /// </summary>
        Transacting = 3,

        /// <summary>
        /// 作废
        /// </summary>
        Invalid = 6,
        Closed = 9
    }

    /// <summary>
    /// 变更单明细类型
    /// </summary>
    public enum AlterDetailType
    {
        Add = 1,
        Cancel = 2
    }

    /// <summary>
    /// 取消采购单状态,该枚举类型与数据库code表同步更新
    /// </summary>
    public enum CancelPurchaseStatus
    {
        New = 0,
        Closed = 9
    }

    /// <summary>
    /// 订单退款类型
    /// </summary>
    public enum RefundStatus
    {
        /// <summary>
        /// 不可发货
        /// </summary>
        NotDelivery = 0,

        /// <summary>
        /// 未退款
        /// </summary>
        NoRefund = 1,

        /// <summary>
        /// 部分退款
        /// </summary>
        PartRefund = 2,

        /// <summary>
        /// 全部退款
        /// </summary>
        FullRefund = 3,

        /// <summary>
        /// 异常
        /// </summary>
        ErrorRefund = 4
    }

    /// <summary>
    /// 退换货审核状态
    /// </summary>
    public enum ReturnGoodsReViewType
    {
        /// <summary>
        /// 客服一审
        /// </summary>
        CusFirstReView = 1,

        /// <summary>
        /// 售后一审
        /// </summary>
        BuyedFirstReView = 2,

        /// <summary>
        /// 客服二审
        /// </summary>
        CusSecondReView = 3,

        /// <summary>
        /// 售后二审
        /// </summary>
        BuyedSecondReView = 4,

        /// <summary>
        /// 仓库审核
        /// </summary>
        WarehouseReView = 5,

        /// <summary>
        /// 采购审核
        /// </summary>
        PurchaseReView = 6,

        /// <summary>
        /// 完成
        /// </summary>
        IsComplete = 9,

        /// <summary>
        /// 新建
        /// </summary>
        AddNew = 90,

        /// <summary>
        /// 新建
        /// </summary>
        Modify = 95,

        /// <summary>
        /// 查看
        /// </summary>
        View = 99
    }

    public enum ReturnSearchType
    {
        /// <summary>
        /// 客服
        /// </summary>
        Business = 1,

        /// <summary>
        /// 售后
        /// </summary>
        Sale = 2,

        /// <summary>
        /// 仓库
        /// </summary>
        Warehouse = 3,

        /// <summary>
        /// 采购
        /// </summary>
        Purchase = 4,

        /// <summary>
        /// 退换货中心
        /// </summary>
        Center = 9
    }

    /// <summary>
    /// 入库类型
    /// </summary>
    public enum InStockType
    {
        /// <summary>
        /// 商品入库
        /// </summary>
        ItemInStock = 1,
        
        /// <summary>
        /// 采购入库
        /// </summary>
        PurchaseInStock = 2
    }

    /// <summary>
    /// 发货状态
    /// </summary>
    public enum DeliveryStatus
    {
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 0,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,

        /// <summary>
        /// 订单状态不能发货
        /// </summary>
        NotDelivery = 2,

        /// <summary>
        /// 库存不足
        /// </summary>
        NotEnough = 3,

        /// <summary>
        /// 已发过货
        /// </summary>
        IsDelivery = 4,

        /// <summary>
        /// 订单数不足
        /// </summary>
        TradeQtyNotEnough = 5,

        /// <summary>
        /// 未完成分拣任务
        /// </summary>
        TradeNotPickPart = 6

    }

    /// <summary>
    /// Author:Frank
    /// 采购单生成状态
    /// </summary>
    public enum AutoPurchase
    {
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 0,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,

        /// <summary>
        /// 无信息或商品未启用
        /// </summary>
        NoItem = 2
    }
}
