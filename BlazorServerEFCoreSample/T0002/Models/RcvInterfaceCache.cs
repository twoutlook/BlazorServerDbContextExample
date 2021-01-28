﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace T0002.Models
{
    public partial class RcvInterfaceCache
    {
        public decimal InterfaceTransactionId { get; set; }
        public decimal? GroupId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public decimal LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal CreatedBy { get; set; }
        public decimal? LastUpdateLogin { get; set; }
        public decimal? RequestId { get; set; }
        public decimal? ProgramApplicationId { get; set; }
        public decimal? ProgramId { get; set; }
        public DateTime? ProgramUpdateDate { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ProcessingStatusCode { get; set; }
        public string ProcessingModeCode { get; set; }
        public decimal? ProcessingRequestId { get; set; }
        public string TransactionStatusCode { get; set; }
        public decimal? CategoryId { get; set; }
        public decimal? Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string InterfaceSourceCode { get; set; }
        public decimal? InterfaceSourceLineId { get; set; }
        public decimal? InvTransactionId { get; set; }
        public decimal? ItemId { get; set; }
        public string ItemDescription { get; set; }
        public string ItemRevision { get; set; }
        public string UomCode { get; set; }
        public decimal? EmployeeId { get; set; }
        public string AutoTransactCode { get; set; }
        public decimal? ShipmentHeaderId { get; set; }
        public decimal? ShipmentLineId { get; set; }
        public decimal? ShipToLocationId { get; set; }
        public decimal? PrimaryQuantity { get; set; }
        public string PrimaryUnitOfMeasure { get; set; }
        public string ReceiptSourceCode { get; set; }
        public decimal? VendorId { get; set; }
        public decimal? VendorSiteId { get; set; }
        public decimal? FromOrganizationId { get; set; }
        public string FromSubinventory { get; set; }
        public decimal? ToOrganizationId { get; set; }
        public decimal? IntransitOwningOrgId { get; set; }
        public decimal? RoutingHeaderId { get; set; }
        public decimal? RoutingStepId { get; set; }
        public string SourceDocumentCode { get; set; }
        public decimal? ParentTransactionId { get; set; }
        public decimal? PoHeaderId { get; set; }
        public decimal? PoRevisionNum { get; set; }
        public decimal? PoReleaseId { get; set; }
        public decimal? PoLineId { get; set; }
        public decimal? PoLineLocationId { get; set; }
        public decimal? PoUnitPrice { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyConversionType { get; set; }
        public decimal? CurrencyConversionRate { get; set; }
        public DateTime? CurrencyConversionDate { get; set; }
        public decimal? PoDistributionId { get; set; }
        public decimal? RequisitionLineId { get; set; }
        public decimal? ReqDistributionId { get; set; }
        public decimal? ChargeAccountId { get; set; }
        public string SubstituteUnorderedCode { get; set; }
        public string ReceiptExceptionFlag { get; set; }
        public string AccrualStatusCode { get; set; }
        public string InspectionStatusCode { get; set; }
        public string InspectionQualityCode { get; set; }
        public string DestinationTypeCode { get; set; }
        public decimal? DeliverToPersonId { get; set; }
        public decimal? LocationId { get; set; }
        public decimal? DeliverToLocationId { get; set; }
        public string Subinventory { get; set; }
        public decimal? LocatorId { get; set; }
        public decimal? WipEntityId { get; set; }
        public decimal? WipLineId { get; set; }
        public string DepartmentCode { get; set; }
        public decimal? WipRepetitiveScheduleId { get; set; }
        public decimal? WipOperationSeqNum { get; set; }
        public decimal? WipResourceSeqNum { get; set; }
        public decimal? BomResourceId { get; set; }
        public string ShipmentNum { get; set; }
        public string FreightCarrierCode { get; set; }
        public string BillOfLading { get; set; }
        public string PackingSlip { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? ExpectedReceiptDate { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? TransferCost { get; set; }
        public decimal? TransportationCost { get; set; }
        public decimal? TransportationAccountId { get; set; }
        public decimal? NumOfContainers { get; set; }
        public string WaybillAirbillNum { get; set; }
        public string VendorItemNum { get; set; }
        public string VendorLotNum { get; set; }
        public string RmaReference { get; set; }
        public string Comments { get; set; }
        public string AttributeCategory { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public string Attribute6 { get; set; }
        public string Attribute7 { get; set; }
        public string Attribute8 { get; set; }
        public string Attribute9 { get; set; }
        public string Attribute10 { get; set; }
        public string Attribute11 { get; set; }
        public string Attribute12 { get; set; }
        public string Attribute13 { get; set; }
        public string Attribute14 { get; set; }
        public string Attribute15 { get; set; }
        public string ShipHeadAttributeCategory { get; set; }
        public string ShipHeadAttribute1 { get; set; }
        public string ShipHeadAttribute2 { get; set; }
        public string ShipHeadAttribute3 { get; set; }
        public string ShipHeadAttribute4 { get; set; }
        public string ShipHeadAttribute5 { get; set; }
        public string ShipHeadAttribute6 { get; set; }
        public string ShipHeadAttribute7 { get; set; }
        public string ShipHeadAttribute8 { get; set; }
        public string ShipHeadAttribute9 { get; set; }
        public string ShipHeadAttribute10 { get; set; }
        public string ShipHeadAttribute11 { get; set; }
        public string ShipHeadAttribute12 { get; set; }
        public string ShipHeadAttribute13 { get; set; }
        public string ShipHeadAttribute14 { get; set; }
        public string ShipHeadAttribute15 { get; set; }
        public string ShipLineAttributeCategory { get; set; }
        public string ShipLineAttribute1 { get; set; }
        public string ShipLineAttribute2 { get; set; }
        public string ShipLineAttribute3 { get; set; }
        public string ShipLineAttribute4 { get; set; }
        public string ShipLineAttribute5 { get; set; }
        public string ShipLineAttribute6 { get; set; }
        public string ShipLineAttribute7 { get; set; }
        public string ShipLineAttribute8 { get; set; }
        public string ShipLineAttribute9 { get; set; }
        public string ShipLineAttribute10 { get; set; }
        public string ShipLineAttribute11 { get; set; }
        public string ShipLineAttribute12 { get; set; }
        public string ShipLineAttribute13 { get; set; }
        public string ShipLineAttribute14 { get; set; }
        public string ShipLineAttribute15 { get; set; }
        public string UssglTransactionCode { get; set; }
        public string GovernmentContext { get; set; }
        public decimal? ReasonId { get; set; }
        public string DestinationContext { get; set; }
        public decimal? SourceDocQuantity { get; set; }
        public string SourceDocUnitOfMeasure { get; set; }
        public decimal? MovementId { get; set; }
        public decimal? HeaderInterfaceId { get; set; }
        public decimal? VendorCumShippedQty { get; set; }
        public string ItemNum { get; set; }
        public string DocumentNum { get; set; }
        public decimal? DocumentLineNum { get; set; }
        public string TruckNum { get; set; }
        public string ShipToLocationCode { get; set; }
        public string ContainerNum { get; set; }
        public string SubstituteItemNum { get; set; }
        public decimal? NoticeUnitPrice { get; set; }
        public string ItemCategory { get; set; }
        public string LocationCode { get; set; }
        public string VendorName { get; set; }
        public string VendorNum { get; set; }
        public string VendorSiteCode { get; set; }
        public string FromOrganizationCode { get; set; }
        public string ToOrganizationCode { get; set; }
        public string IntransitOwningOrgCode { get; set; }
        public string RoutingCode { get; set; }
        public string RoutingStep { get; set; }
        public decimal? ReleaseNum { get; set; }
        public decimal? DocumentShipmentLineNum { get; set; }
        public decimal? DocumentDistributionNum { get; set; }
        public string DeliverToPersonName { get; set; }
        public string DeliverToLocationCode { get; set; }
        public decimal? UseMtlLot { get; set; }
        public decimal? UseMtlSerial { get; set; }
        public string Locator { get; set; }
        public string ReasonName { get; set; }
        public string ValidationFlag { get; set; }
        public decimal? SubstituteItemId { get; set; }
        public decimal? QuantityShipped { get; set; }
        public decimal? QuantityInvoiced { get; set; }
        public string TaxName { get; set; }
        public decimal? TaxAmount { get; set; }
        public string ReqNum { get; set; }
        public decimal? ReqLineNum { get; set; }
        public decimal? ReqDistributionNum { get; set; }
        public string WipEntityName { get; set; }
        public string WipLineCode { get; set; }
        public string ResourceCode { get; set; }
        public string ShipmentLineStatusCode { get; set; }
        public string BarcodeLabel { get; set; }
        public decimal? TransferPercentage { get; set; }
        public decimal? QaCollectionId { get; set; }
        public string CountryOfOriginCode { get; set; }
        public decimal? OeOrderHeaderId { get; set; }
        public decimal? OeOrderLineId { get; set; }
        public decimal? CustomerId { get; set; }
        public decimal? CustomerSiteId { get; set; }
        public string CustomerItemNum { get; set; }
        public string CreateDebitMemoFlag { get; set; }
        public decimal? PutAwayRuleId { get; set; }
        public decimal? PutAwayStrategyId { get; set; }
        public decimal? LpnId { get; set; }
        public decimal? TransferLpnId { get; set; }
        public decimal? CostGroupId { get; set; }
        public string MobileTxn { get; set; }
        public decimal? MmttTempId { get; set; }
        public decimal? TransferCostGroupId { get; set; }
        public decimal? SecondaryQuantity { get; set; }
        public string SecondaryUnitOfMeasure { get; set; }
        public string SecondaryUomCode { get; set; }
        public string QcGrade { get; set; }
        public string FromLocator { get; set; }
        public decimal? FromLocatorId { get; set; }
        public string ParentSourceTransactionNum { get; set; }
        public decimal? InterfaceAvailableQty { get; set; }
        public decimal? InterfaceTransactionQty { get; set; }
        public decimal? InterfaceAvailableAmt { get; set; }
        public decimal? InterfaceTransactionAmt { get; set; }
        public string LicensePlateNumber { get; set; }
        public string SourceTransactionNum { get; set; }
        public string TransferLicensePlateNumber { get; set; }
        public decimal? LpnGroupId { get; set; }
        public decimal? OrderTransactionId { get; set; }
        public decimal? CustomerAccountNumber { get; set; }
        public string CustomerPartyName { get; set; }
        public decimal? OeOrderLineNum { get; set; }
        public decimal? OeOrderNum { get; set; }
        public decimal? ParentInterfaceTxnId { get; set; }
        public decimal? CustomerItemId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? JobId { get; set; }
        public decimal? TimecardId { get; set; }
        public decimal? TimecardOvn { get; set; }
        public decimal? ErecordId { get; set; }
        public decimal? ProjectId { get; set; }
        public decimal? TaskId { get; set; }
        public decimal? AsnAttachId { get; set; }
        public decimal? OrgId { get; set; }
        public string OperatingUnit { get; set; }
        public decimal? RequestedAmount { get; set; }
        public decimal? MaterialStoredAmount { get; set; }
        public decimal? AmountShipped { get; set; }
        public string MatchingBasis { get; set; }
        public decimal? ReplenishOrderLineId { get; set; }
        public string ExpressTransaction { get; set; }
        public decimal? LcmShipmentLineId { get; set; }
        public decimal? UnitLandedCost { get; set; }
        public decimal? LcmAdjustmentNum { get; set; }
    }
}