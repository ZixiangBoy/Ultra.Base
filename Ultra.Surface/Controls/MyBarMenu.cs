using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Ultra.Surface.Controls
{
    public partial class MyBarMenu : DevExpress.XtraEditors.XtraUserControl
    {
        #region [按钮 Enabled]

        [Category("APEX"),Description("新增按钮"),Browsable(true)]
        public bool 新增{
            get { return this.btnCreate.Enabled; }
            set { this.btnCreate.Enabled = value; }
        }
        [Category("APEX"), Description("修改按钮"), Browsable(true)]
        public bool 修改{
            get { return this.btnModify.Enabled; }
            set { this.btnModify.Enabled = value; }
        }
        [Category("APEX"), Description("删除按钮"), Browsable(true)]
        public bool 删除 {
            get { return this.btnRemove.Enabled; }
            set { this.btnRemove.Enabled = value; }
        }
        [Category("APEX"), Description("锁定按钮"), Browsable(true)]
        public bool 锁定 {
            get { return this.btnLock.Enabled; }
            set { this.btnLock.Enabled = value; }
        }
        [Category("APEX"), Description("解锁按钮"), Browsable(true)]
        public bool 解锁 {
            get { return this.btnUnLock.Enabled; }
            set { this.btnUnLock.Enabled = value; }
        }
        [Category("APEX"), Description("审核按钮"), Browsable(true)]
        public bool 审核 {
            get { return this.btnReView.Enabled; }
            set { this.btnReView.Enabled = value; }
        }
        [Category("APEX"), Description("退审按钮"), Browsable(true)]
        public bool 退审 {
            get { return this.btnUnReView.Enabled; }
            set { this.btnUnReView.Enabled = value; }
        }
        [Category("APEX"), Description("发货按钮"), Browsable(true)]
        public bool 发货 {
            get { return this.btnGoods.Enabled; }
            set { this.btnGoods.Enabled = value; }
        }
        [Category("APEX"), Description("导入按钮"), Browsable(true)]
        public bool 导入 {
            get { return this.btnImport.Enabled; }
            set { this.btnImport.Enabled = value; }
        }
        [Category("APEX"), Description("导出按钮"), Browsable(true)]
        public bool 导出 {
            get { return this.btnExport.Enabled; }
            set { this.btnExport.Enabled = value; }
        }
        [Category("APEX"), Description("物流单按钮"), Browsable(true)]
        public bool 物流单 {
            get { return this.btnLogDocument.Enabled; }
            set { this.btnLogDocument.Enabled = value; }
        }
        [Category("APEX"), Description("发货单按钮"), Browsable(true)]
        public bool 发货单 {
            get { return this.btnGoodsDocument.Enabled; }
            set { this.btnGoodsDocument.Enabled = value; }
        }
        [Category("APEX"), Description("合并按钮"), Browsable(true)]
        public bool 合并 {
            get { return this.btnMerge.Enabled; }
            set { this.btnMerge.Enabled = value; }
        }
        [Category("APEX"), Description("拆分按钮"), Browsable(true)]
        public bool 拆分 {
            get { return this.btnSplit.Enabled; }
            set { this.btnSplit.Enabled = value; }
        }
        [Category("APEX"), Description("发短信按钮"), Browsable(true)]
        public bool 发短信 {
            get { return this.btnSMS.Enabled; }
            set { this.btnSMS.Enabled = value; }
        }
        [Category("APEX"), Description("同步按钮"), Browsable(true)]
        public bool 同步 {
            get { return this.btnSyn.Enabled; }
            set { this.btnSyn.Enabled = value; }
        }
        [Category("APEX"), Description("上传按钮"), Browsable(true)]
        public bool 上传 {
            get { return this.btnUpload.Enabled; }
            set { this.btnUpload.Enabled = value; }
        }
        [Category("APEX"), Description("下载按钮"), Browsable(true)]
        public bool 下载 {
            get { return this.btnDownload.Enabled; }
            set { this.btnDownload.Enabled = value; }
        }
        [Category("APEX"), Description("刷新按钮"), Browsable(true)]
        public bool 刷新 {
            get { return this.btnRefresh.Enabled; }
            set { this.btnRefresh.Enabled = value; }
        }
        [Category("APEX"), Description("上一条按钮"), Browsable(true)]
        public bool 上一条
        {
            get { return this.btnPrePage.Enabled; }
            set { this.btnPrePage.Enabled = value; }
        }
        [Category("APEX"), Description("下一条按钮"), Browsable(true)]
        public bool 下一条
        {
            get { return this.btnNextPage.Enabled; }
            set { this.btnNextPage.Enabled = value; }
        }
        [Category("APEX"), Description("转补款单按钮"), Browsable(true)]
        public bool 转补款单
        {
            get { return this.btnConvertReplan.Enabled; }
            set { this.btnConvertReplan.Enabled = value; }
        }
        [Category("APEX"),Description("关联按钮"),Browsable(true)]
        public bool 关联
        {
            get { return this.btnReleva.Enabled; }
            set { this.btnReleva.Enabled = value; }
        }
        [Category("APEX"),Description("订单采购按钮"),Browsable(true)]
        public bool 订单采购
        {
            get { return this.btnPurchase.Enabled; }
            set { this.btnPurchase.Enabled = value; }
        }
        [Category("APEX"),Description("获取订单按钮"),Browsable(true)]
        public bool 获取订单
        {
            get { return this.btnRequest.Enabled; }
            set { this.btnRequest.Enabled = value; }
        }
        [Category("APEX"),Description("重下订单按钮"),Browsable(true)]
        public bool 重下订单
        {
            get { return this.btnAgainDown.Enabled; }
            set { this.btnAgainDown.Enabled = value; }
        }
        [Category("APEX"), Description("打印按钮"), Browsable(true)]
        public bool 打印
        {
            get { return this.btnPrint.Enabled; }
            set { this.btnPrint.Enabled = value; }
        }
        [Category("APEX"), Description("退打印按钮"), Browsable(true)]
        public bool 退打印 {
            get { return this.btnUnPrint.Enabled; }
            set { this.btnUnPrint.Enabled = value; }
        }
        [Category("APEX"), Description("角色权限按钮"), Browsable(true)]
        public bool 角色权限
        {
            get { return this.btnAuthorPur.Enabled; }
            set { this.btnAuthorPur.Enabled = value; }
        }
        [Category("APEX"), Description("角色用户按钮"), Browsable(true)]
        public bool 角色用户
        {
            get { return this.btnAuthorUser.Enabled; }
            set { this.btnAuthorUser.Enabled = value; }
        }
        [Category("APEX"), Description("生成"), Browsable(true)]
        public bool 生成 {
            get { return this.btnGen.Enabled; }
            set { this.btnGen.Enabled = value; }
        }
        //[Category("APEX"), Description("货审按钮"), Browsable(true)]
        //public bool 货审
        //{
        //    get { return this.btnHouseReView.Enabled; }
        //    set { this.btnHouseReView.Enabled = value; }
        //}
        [Category("APEX"), Description("备份按钮"), Browsable(true)]
        public bool 备份
        {
            get { return this.btnBackUp.Enabled; }
            set { this.btnBackUp.Enabled = value; }
        }
        [Category("APEX"), Description("调货"), Browsable(true)]
        public bool 调货 {
            get { return this.btnTraferCargo.Enabled; }
            set { this.btnTraferCargo.Enabled = value; }
        }
        [Category("APEX"), Description("还原按钮"), Browsable(true)]
        public bool 还原
        {
            get { return this.btnRevert.Enabled; }
            set { this.btnRevert.Enabled = value; }
        }
        [Category("APEX"), Description("作废按钮"), Browsable(true)]
        public bool 作废
        {
            get { return this.btnInvalid.Enabled; }
            set { this.btnInvalid.Enabled = value; }
        }
        [Category("APEX"), Description("提交按钮"), Browsable(true)]
        public bool 提交
        {
            get { return this.btnSubmit.Enabled; }
            set { this.btnSubmit.Enabled = value; }
        }
        [Category("APEX"), Description("获取按钮"), Browsable(true)]
        public bool 获取
        {
            get { return this.btnRequestSource.Enabled; }
            set { this.btnRequestSource.Enabled = value; }
        }
        [Category("APEX"), Description("取消关联按钮"), Browsable(true)]
        public bool 取消关联
        {
            get { return this.btnUnReplation.Enabled; }
            set { this.btnUnReplation.Enabled = value; }
        }
        [Category("APEX"),Description("结算按钮"),Browsable(true)]
        public bool 结算
        {
            get { return this.btnPayed.Enabled; }
            set { this.btnPayed.Enabled = value; }
        }
        [Category("APEX"), Description("停止生产"), Browsable(true)]
        public bool 停止生产
        {
            get { return this.btnStopOutput.Enabled; }
            set { this.btnStopOutput.Enabled = value; }
        }
        [Category("APEX"), Description("发邮件"), Browsable(true)]
        public bool 发邮件
        {
            get { return this.btnSendEmail.Enabled; }
            set { this.btnSendEmail.Enabled = value; }
        }
        [Category("APEX"), Description("发红包"), Browsable(true)]
        public bool 发红包
        {
            get { return this.btnSendMoney.Enabled; }
            set { this.btnSendMoney.Enabled = value; }
        }
        [Category("APEX"),Description("短信充值"),Browsable(true)]
        public bool 短信充值
        {
            get { return this.btnRecharge.Enabled; }
            set { this.btnRecharge.Enabled = value; }
        }
        [Category("APEX"), Description("转赠品"), Browsable(true)]
        public bool 转赠品
        {
            get { return this.btnCast.Enabled; }
            set { this.btnCast.Enabled = value; }
        }
        [Category("APEX"), Description("启用"), Browsable(true)]
        public bool 启用
        {
            get { return this.btnUsing.Enabled; }
            set { this.btnUsing.Enabled = value; }
        }
        [Category("APEX"), Description("未启用"), Browsable(true)]
        public bool 未启用
        {
            get { return this.btnUnUsing.Enabled; }
            set { this.btnUnUsing.Enabled = value; }
        }
        [Category("APEX"), Description("财审"), Browsable(true)]
        public bool 财审
        {
            get { return this.btnFinReView.Enabled; }
            set { this.btnFinReView.Enabled = value; }
        }
        [Category("APEX"), Description("标签打印"), Browsable(true)]
        public bool 标签打印
        {
            get { return this.btnTagPrint.Enabled; }
            set { this.btnTagPrint.Enabled = value; }
        }
        [Category("APEX"), Description("理货打印"), Browsable(true)]
        public bool 理货打印
        {
            get { return this.btnTocPrint.Enabled; }
            set { this.btnTocPrint.Enabled = value; }
        }
        [Category("APEX"), Description("分配商品"), Browsable(true)]
        public bool 分配商品
        {
            get { return this.btnaAlot.Enabled; }
            set { this.btnaAlot.Enabled = value; }
        }
        [Category("APEX"), Description("申请打印"), Browsable(true)]
        public bool 申请打印
        {
            get { return this.btnAFP.Enabled; }
            set { this.btnAFP.Enabled = value; }
        }
        [Category("APEX"), Description("维修到货"), Browsable(true)]
        public bool 维修到货
        {
            get { return this.btnArrival.Enabled; }
            set { this.btnArrival.Enabled = value; }
        }
        [Category("APEX"), Description("折价退回"), Browsable(true)]
        public bool 折价退回
        {
            get { return this.btnCRP.Enabled; }
            set { this.btnCRP.Enabled = value; }
        }
        [Category("APEX"), Description("直接入库"), Browsable(true)]
        public bool 直接入库
        {
            get { return this.btnDirectStorage.Enabled; }
            set { this.btnDirectStorage.Enabled = value; }
        }
        [Category("APEX"), Description("永久折扣"), Browsable(true)]
        public bool 永久折扣
        {
            get { return this.btnDiscount.Enabled; }
            set { this.btnDiscount.Enabled = value; }
        }
        [Category("APEX"), Description("报废"), Browsable(true)]
        public bool 报废
        {
            get { return this.btnDump.Enabled; }
            set { this.btnDump.Enabled = value; }
        }
        [Category("APEX"), Description("优惠规则"), Browsable(true)]
        public bool 优惠规则
        {
            get { return this.btnFavourable.Enabled; }
            set { this.btnFavourable.Enabled = value; }
        }
        [Category("APEX"), Description("返厂维修"), Browsable(true)]
        public bool 返厂维修
        {
            get { return this.btnKeep.Enabled; }
            set { this.btnKeep.Enabled = value; }
        }
        [Category("APEX"), Description("临时入库"), Browsable(true)]
        public bool 临时入库
        {
            get { return this.btnLaid.Enabled; }
            set { this.btnLaid.Enabled = value; }
        }
        [Category("APEX"), Description("驳回"), Browsable(true)]
        public bool 驳回
        {
            get { return this.btnReject.Enabled; }
            set { this.btnReject.Enabled = value; }
        }
        [Category("APEX"), Description("回访"), Browsable(true)]
        public bool 回访
        {
            get { return this.btnReBack.Enabled; }
            set { this.btnReBack.Enabled = value; }
        }
        [Category("APEX"), Description("纠纷"), Browsable(true)]
        public bool 纠纷 {
            get { return this.btnDispute.Enabled; }
            set { this.btnDispute.Enabled = value; }
        }
        [Category("APEX"), Description("库存采购"), Browsable(true)]
        public bool 库存采购
        {
            get { return this.btnInv.Enabled; }
            set { this.btnInv.Enabled = value; }
        }
        [Category("APEX"), Description("打印预览"), Browsable(true)]
        public bool 打印预览 {
            get { return this.btnPrintView.Enabled; }
            set { this.btnPrintView.Enabled = value; }
        }
        [Category("APEX"), Description("变更"), Browsable(true)]
        public bool 变更 {
            get { return this.btnChange.Enabled; }
            set { this.btnChange.Enabled = value; }
        }
        [Category("APEX"), Description("收工"), Browsable(true)]
        public bool 收工 {
            get { return this.btnKnockOff.Enabled; }
            set { this.btnKnockOff.Enabled = value; }
        }
        #endregion



















        #region [按钮 Visibility]

        [Category("APEX"), Description("新增按钮"), Browsable(true)]
        public BarItemVisibility 新增Visible
        {
            get { return this.btnCreate.Visibility; }
            set { this.btnCreate.Visibility = value; }
        }
        [Category("APEX"), Description("修改按钮"), Browsable(true)]
        public BarItemVisibility 修改Visible
        {
            get { return this.btnModify.Visibility; }
            set { this.btnModify.Visibility = value; }
        }
        [Category("APEX"), Description("删除按钮"), Browsable(true)]
        public BarItemVisibility 删除Visible
        {
            get { return this.btnRemove.Visibility; }
            set { this.btnRemove.Visibility = value; }
        }
        [Category("APEX"), Description("锁定按钮"), Browsable(true)]
        public BarItemVisibility 锁定Visible
        {
            get { return this.btnLock.Visibility; }
            set { this.btnLock.Visibility = value; }
        }
        [Category("APEX"), Description("解锁按钮"), Browsable(true)]
        public BarItemVisibility 解锁Visible
        {
            get { return this.btnUnLock.Visibility; }
            set { this.btnUnLock.Visibility = value; }
        }
        [Category("APEX"), Description("审核按钮"), Browsable(true)]
        public BarItemVisibility 审核Visible
        {
            get { return this.btnReView.Visibility; }
            set { this.btnReView.Visibility = value; }
        }
        [Category("APEX"), Description("退审按钮"), Browsable(true)]
        public BarItemVisibility 退审Visible
        {
            get { return this.btnUnReView.Visibility; }
            set { this.btnUnReView.Visibility = value; }
        }
        [Category("APEX"), Description("发货按钮"), Browsable(true)]
        public BarItemVisibility 发货Visible
        {
            get { return this.btnGoods.Visibility; }
            set { this.btnGoods.Visibility = value; }
        }
        [Category("APEX"), Description("导入按钮"), Browsable(true)]
        public BarItemVisibility 导入Visible
        {
            get { return this.btnImport.Visibility; }
            set { this.btnImport.Visibility = value; }
        }
        [Category("APEX"), Description("导出按钮"), Browsable(true)]
        public BarItemVisibility 导出Visible
        {
            get { return this.btnExport.Visibility; }
            set { this.btnExport.Visibility = value; }
        }
        [Category("APEX"), Description("完结按钮"), Browsable(true)]
        public BarItemVisibility 完结Visible
        {
            get { return this.btnCmp.Visibility; }
            set { this.btnCmp.Visibility = value; }
        }
        [Category("APEX"), Description("物流单按钮"), Browsable(true)]
        public BarItemVisibility 物流单Visible
        {
            get { return this.btnLogDocument.Visibility; }
            set { this.btnLogDocument.Visibility = value; }
        }
        [Category("APEX"), Description("发货单按钮"), Browsable(true)]
        public BarItemVisibility 发货单Visible
        {
            get { return this.btnGoodsDocument.Visibility; }
            set { this.btnGoodsDocument.Visibility = value; }
        }
        [Category("APEX"), Description("合并按钮"), Browsable(true)]
        public BarItemVisibility 合并Visible
        {
            get { return this.btnMerge.Visibility; }
            set { this.btnMerge.Visibility = value; }
        }
        [Category("APEX"), Description("拆分按钮"), Browsable(true)]
        public BarItemVisibility 拆分Visible
        {
            get { return this.btnSplit.Visibility; }
            set { this.btnSplit.Visibility = value; }
        }
        [Category("APEX"), Description("发短信按钮"), Browsable(true)]
        public BarItemVisibility 发短信Visible
        {
            get { return this.btnSMS.Visibility; }
            set { this.btnSMS.Visibility = value; }
        }
        [Category("APEX"), Description("同步按钮"), Browsable(true)]
        public BarItemVisibility 同步Visible
        {
            get { return this.btnSyn.Visibility; }
            set { this.btnSyn.Visibility = value; }
        }
        [Category("APEX"), Description("上传按钮"), Browsable(true)]
        public BarItemVisibility 上传Visible
        {
            get { return this.btnUpload.Visibility; }
            set { this.btnUpload.Visibility = value; }
        }
        [Category("APEX"), Description("下载按钮"), Browsable(true)]
        public BarItemVisibility 下载Visible
        {
            get { return this.btnDownload.Visibility; }
            set { this.btnDownload.Visibility = value; }
        }
        [Category("APEX"), Description("刷新按钮"), Browsable(true)]
        public BarItemVisibility 刷新Visible
        {
            get { return this.btnRefresh.Visibility; }
            set { this.btnRefresh.Visibility = value; }
        }

        [Category("APEX"), Description("上一条按钮"), Browsable(true)]
        public BarItemVisibility 上一条Visible
        {
            get { return this.btnPrePage.Visibility; }
            set { this.btnPrePage.Visibility = value; }
        }
        [Category("APEX"), Description("下一条按钮"), Browsable(true)]
        public BarItemVisibility 下一条Visible
        {
            get { return this.btnNextPage.Visibility; }
            set { this.btnNextPage.Visibility = value; }
        }
        [Category("APEX"), Description("转补款单按钮"), Browsable(true)]
        public BarItemVisibility 转补款单Visible
        {
            get { return this.btnConvertReplan.Visibility; }
            set { this.btnConvertReplan.Visibility = value; }
        }
        [Category("APEX"), Description("关联按钮"), Browsable(true)]
        public BarItemVisibility 关联Visible
        {      
            get { return this.btnReleva.Visibility; }
            set { this.btnReleva.Visibility = value; }
        }
        [Category("APEX"), Description("订单采购按钮"), Browsable(true)]
        public BarItemVisibility 订单采购Visible
        {
            get { return this.btnPurchase.Visibility; }
            set { this.btnPurchase.Visibility = value; }
        }
        [Category("APEX"), Description("获取订单按钮"), Browsable(true)]
        public BarItemVisibility 获取订单Visible
        {
            get { return this.btnRequest.Visibility; }
            set { this.btnRequest.Visibility = value; }
        }
        [Category("APEX"), Description("重下订单按钮"), Browsable(true)]
        public BarItemVisibility 重下订单Visible
        {
            get { return this.btnAgainDown.Visibility; }
            set { this.btnAgainDown.Visibility = value; }
        }
        [Category("APEX"), Description("打印按钮"), Browsable(true)]
        public BarItemVisibility 打印Visible
        {
            get { return this.btnPrint.Visibility; }
            set { this.btnPrint.Visibility = value; }
        }
        [Category("APEX"), Description("生成"), Browsable(true)]
        public BarItemVisibility 生成Visible {
            get { return this.btnGen.Visibility; }
            set { this.btnGen.Visibility = value; }
        }
        [Category("APEX"), Description("退打印按钮"), Browsable(true)]
        public BarItemVisibility 退打印Visible {
            get { return this.btnUnPrint.Visibility; }
            set { this.btnUnPrint.Visibility = value; }
        }
        [Category("APEX"), Description("角色权限按钮"), Browsable(true)]
        public BarItemVisibility 角色权限Visible
        {
            get { return this.btnAuthorPur.Visibility; }
            set { this.btnAuthorPur.Visibility = value; }
        }
        [Category("APEX"), Description("角色用户按钮"), Browsable(true)]
        public BarItemVisibility 角色用户Visible
        {
            get { return this.btnAuthorUser.Visibility; }
            set { this.btnAuthorUser.Visibility = value; }
        }
        [Category("APEX"), Description("货审按钮"), Browsable(true)]
        public BarItemVisibility 货审Visible {
            get { return this.btnHouseReView.Visibility; }
            set { this.btnHouseReView.Visibility = value; }
        }
        [Category("APEX"), Description("备份按钮"), Browsable(true)]
        public BarItemVisibility 备份Visible
        {
            get { return this.btnBackUp.Visibility; }
            set { this.btnBackUp.Visibility = value; }
        }
        [Category("APEX"), Description("还原按钮"), Browsable(true)]
        public BarItemVisibility 还原Visible
        {
            get { return this.btnRevert.Visibility; }
            set { this.btnRevert.Visibility = value; }
        }
        [Category("APEX"), Description("作废按钮"), Browsable(true)]
        public BarItemVisibility 作废Visible
        {
            get { return this.btnInvalid.Visibility; }
            set { this.btnInvalid.Visibility = value; }
        }
        [Category("APEX"), Description("提交按钮"), Browsable(true)]
        public BarItemVisibility 提交Visible
        {
            get { return this.btnSubmit.Visibility; }
            set { this.btnSubmit.Visibility = value; }
        }
        [Category("APEX"), Description("获取按钮"), Browsable(true)]
        public BarItemVisibility 获取Visible
        {
            get { return this.btnRequestSource.Visibility; }
            set { this.btnRequestSource.Visibility = value; }
        }
        [Category("APEX"), Description("取消关联按钮"), Browsable(true)]
        public BarItemVisibility 取消关联Visible
        {
            get { return this.btnUnReplation.Visibility; }
            set { this.btnUnReplation.Visibility = value; }
        }
        [Category("APEX"),Description("结算按钮"),Browsable(true)]
        public BarItemVisibility 结算Visible
        {
            get { return this.btnPayed.Visibility; }
            set { this.btnPayed.Visibility = value; }
        }
        [Category("APEX"), Description("停止生产"), Browsable(true)]
        public BarItemVisibility 停止生产Visible
        {
            get { return this.btnStopOutput.Visibility; }
            set { this.btnStopOutput.Visibility = value; }
        }
        [Category("APEX"), Description("发邮件"), Browsable(true)]
        public BarItemVisibility 发邮件Visible
        {
            get { return this.btnSendEmail.Visibility; }
            set { this.btnSendEmail.Visibility = value; }
        }
        [Category("APEX"), Description("发红包"), Browsable(true)]
        public BarItemVisibility 发红包Visible
        {
            get { return this.btnSendMoney.Visibility; }
            set { this.btnSendMoney.Visibility = value; }
        }
        [Category("APEX"), Description("短信充值"), Browsable(true)]
        public BarItemVisibility 短信充值Visible
        {
            get { return this.btnRecharge.Visibility; }
            set { this.btnRecharge.Visibility = value; }
        }
        [Category("APEX"), Description("转赠品"), Browsable(true)]
        public BarItemVisibility 转赠品Visible
        {
            get { return this.btnCast.Visibility; }
            set { this.btnCast.Visibility = value; }
        }
        [Category("APEX"), Description("启用"), Browsable(true)]
        public BarItemVisibility 启用Visible
        {
            get { return this.btnUsing.Visibility; }
            set { this.btnUsing.Visibility = value; }
        }
        [Category("APEX"), Description("未启用"), Browsable(true)]
        public BarItemVisibility 未启用Visible
        {
            get { return this.btnUnUsing.Visibility; }
            set { this.btnUnUsing.Visibility = value; }
        }
        [Category("APEX"), Description("财审"), Browsable(true)]
        public BarItemVisibility 财审Visible
        {
            get { return this.btnFinReView.Visibility; }
            set { this.btnFinReView.Visibility = value; }
        }
        [Category("APEX"), Description("标签打印"), Browsable(true)]
        public BarItemVisibility 标签打印Visible
        {
            get { return this.btnTagPrint.Visibility; }
            set { this.btnTagPrint.Visibility = value; }
        }
        [Category("APEX"), Description("理货打印"), Browsable(true)]
        public BarItemVisibility 理货打印Visible
        {
            get { return this.btnTocPrint.Visibility; }
            set { this.btnTocPrint.Visibility = value; }
        }
        [Category("APEX"), Description("分配商品"), Browsable(true)]
        public BarItemVisibility 分配商品Visible
        {
            get { return this.btnaAlot.Visibility; }
            set { this.btnaAlot.Visibility = value; }
        }
        [Category("APEX"), Description("申请打印"), Browsable(true)]
        public BarItemVisibility 申请打印Visible
        {
            get { return this.btnAFP.Visibility; }
            set { this.btnAFP.Visibility = value; }
        }
        [Category("APEX"), Description("维修到货"), Browsable(true)]
        public BarItemVisibility 维修到货Visible
        {
            get { return this.btnArrival.Visibility; }
            set { this.btnArrival.Visibility = value; }
        }
        [Category("APEX"), Description("折价退回"), Browsable(true)]
        public BarItemVisibility 折价退回Visible
        {
            get { return this.btnCRP.Visibility; }
            set { this.btnCRP.Visibility = value; }
        }
        [Category("APEX"), Description("直接入库"), Browsable(true)]
        public BarItemVisibility 直接入库Visible
        {
            get { return this.btnDirectStorage.Visibility; }
            set { this.btnDirectStorage.Visibility = value; }
        }
        [Category("APEX"), Description("永久折扣"), Browsable(true)]
        public BarItemVisibility 永久折扣Visible
        {
            get { return this.btnDiscount.Visibility; }
            set { this.btnDiscount.Visibility = value; }
        }
        [Category("APEX"), Description("报废"), Browsable(true)]
        public BarItemVisibility 报废Visible
        {
            get { return this.btnDump.Visibility; }
            set { this.btnDump.Visibility = value; }
        }
        [Category("APEX"), Description("优惠规则"), Browsable(true)]
        public BarItemVisibility 优惠规则Visible
        {
            get { return this.btnFavourable.Visibility; }
            set { this.btnFavourable.Visibility = value; }
        }
        [Category("APEX"), Description("返厂维修"), Browsable(true)]
        public BarItemVisibility 返厂维修Visible
        {
            get { return this.btnKeep.Visibility; }
            set { this.btnKeep.Visibility = value; }
        }
        [Category("APEX"), Description("临时入库"), Browsable(true)]
        public BarItemVisibility 临时入库Visible
        {
            get { return this.btnLaid.Visibility; }
            set { this.btnLaid.Visibility = value; }
        }
        [Category("APEX"), Description("驳回"), Browsable(true)]
        public BarItemVisibility 驳回Visible
        {
            get { return this.btnReject.Visibility; }
            set { this.btnReject.Visibility = value; }
        }
        [Category("APEX"), Description("回访"), Browsable(true)]
        public BarItemVisibility 回访Visible
        {
            get { return this.btnReBack.Visibility; }
            set { this.btnReBack.Visibility = value; }
        }
        [Category("APEX"), Description("纠纷"), Browsable(true)]
        public BarItemVisibility 纠纷Visible {
            get { return this.btnDispute.Visibility; }
            set { this.btnDispute.Visibility = value; }
        }
        [Category("APEX"), Description("库存采购"), Browsable(true)]
        public BarItemVisibility 库存采购Visible
        {
            get { return this.btnInv.Visibility; }
            set { this.btnInv.Visibility = value; }
        }
        [Category("APEX"), Description("打印预览"), Browsable(true)]
        public BarItemVisibility 打印预览Visible {
            get { return this.btnPrintView.Visibility; }
            set { this.btnPrintView.Visibility = value; }
        }
        [Category("APEX"), Description("变更"), Browsable(true)]
        public BarItemVisibility 变更Visible {
            get { return this.btnChange.Visibility; }
            set { this.btnChange.Visibility = value; }
        }
        [Category("APEX"), Description("调货"), Browsable(true)]
        public BarItemVisibility 调货Visible {
            get { return this.btnTraferCargo.Visibility; }
            set { this.btnTraferCargo.Visibility = value; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public MyBarMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyBarMenu_Load(object sender, EventArgs e)
        {
            
        }






    }
}
