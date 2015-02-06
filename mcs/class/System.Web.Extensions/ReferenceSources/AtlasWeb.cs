//
// AtlasWeb.cs: Manually collected resource strings for ReferenceSources
//
// Authors:
//	Alexander Köplinger  <alex.koeplinger@outlook.com>
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System.Globalization;

namespace System.Web.Resources
{

class AtlasWeb
{
	internal static class ResourceManager
	{
		internal static string GetString (string key, string culture)
		{
			return key;
		}
	}

	public const string AppService_Disabled = "AppService_Disabled";
	public const string AppService_MultiplePaths = "AppService_MultiplePaths";
	public const string AppService_RequiredSSL = "AppService_RequiredSSL";
	public const string AppService_UnknownProfileProperty = "AppService_UnknownProfileProperty";
	public const string ArgumentMustBeCurrentUser = "ArgumentMustBeCurrentUser";
	public const string ArgumentMustBeNull = "ArgumentMustBeNull";
	public const string AsyncPostBackTrigger_CannotFindEvent = "AsyncPostBackTrigger_CannotFindEvent";
	public const string AsyncPostBackTrigger_InvalidEvent = "AsyncPostBackTrigger_InvalidEvent";
	public const string AttributeNotRecognized = "AttributeNotRecognized";
	public const string ClientService_BadJsonResponse = "ClientService_BadJsonResponse";
	public const string Common_ArgumentInvalidType = "Common_ArgumentInvalidType";
	public const string Common_NullOrEmpty = "Common_NullOrEmpty";
	public const string Common_PageCannotBeNull = "Common_PageCannotBeNull";
	public const string Common_ScriptManagerRequired = "Common_ScriptManagerRequired";
	public const string ConvertersCollection_NotJavaScriptConverter = "ConvertersCollection_NotJavaScriptConverter";
	public const string ConvertersCollection_UnknownType = "ConvertersCollection_UnknownType";
	public const string Culture = "Culture";
	public const string DataPager_ControlIsntPageable = "DataPager_ControlIsntPageable";
	public const string DataPager_NoNamingContainer = "DataPager_NoNamingContainer";
	public const string DataPager_NoPageableItemContainer = "DataPager_NoPageableItemContainer";
	public const string DataPager_PageableItemContainerNotFound = "DataPager_PageableItemContainerNotFound";
	public const string DataPager_PagePropertiesCannotBeSet = "DataPager_PagePropertiesCannotBeSet";
	public const string DataSourceControlExtender_TargetControlIDMustBeSpecified = "DataSourceControlExtender_TargetControlIDMustBeSpecified";
	public const string ExpressionParser_AmbiguousConstructorInvocation = "ExpressionParser_AmbiguousConstructorInvocation";
	public const string ExpressionParser_AmbiguousIndexerInvocation = "ExpressionParser_AmbiguousIndexerInvocation";
	public const string ExpressionParser_AmbiguousMethodInvocation = "ExpressionParser_AmbiguousMethodInvocation";
	public const string ExpressionParser_ArgsIncompatibleWithLambda = "ExpressionParser_ArgsIncompatibleWithLambda";
	public const string ExpressionParser_BothTypesConvertToOther = "ExpressionParser_BothTypesConvertToOther";
	public const string ExpressionParser_CannotConvertValue = "ExpressionParser_CannotConvertValue";
	public const string ExpressionParser_CannotIndexMultipleDimensionalArray = "ExpressionParser_CannotIndexMultipleDimensionalArray";
	public const string ExpressionParser_CloseBracketOrCommaExpected = "ExpressionParser_CloseBracketOrCommaExpected";
	public const string ExpressionParser_CloseParenOrCommaExpected = "ExpressionParser_CloseParenOrCommaExpected";
	public const string ExpressionParser_CloseParenOrOperatorExpected = "ExpressionParser_CloseParenOrOperatorExpected";
	public const string ExpressionParser_ColonExpected = "ExpressionParser_ColonExpected";
	public const string ExpressionParser_DigitExpected = "ExpressionParser_DigitExpected";
	public const string ExpressionParser_DotOrOpenParenExpected = "ExpressionParser_DotOrOpenParenExpected";
	public const string ExpressionParser_DuplicateIdentifier = "ExpressionParser_DuplicateIdentifier";
	public const string ExpressionParser_ExpressionExpected = "ExpressionParser_ExpressionExpected";
	public const string ExpressionParser_ExpressionTypeMismatch = "ExpressionParser_ExpressionTypeMismatch";
	public const string ExpressionParser_FirstExprMustBeBool = "ExpressionParser_FirstExprMustBeBool";
	public const string ExpressionParser_IdentifierExpected = "ExpressionParser_IdentifierExpected";
	public const string ExpressionParser_IifRequiresThreeArgs = "ExpressionParser_IifRequiresThreeArgs";
	public const string ExpressionParser_IncompatibleOperand = "ExpressionParser_IncompatibleOperand";
	public const string ExpressionParser_IncompatibleOperands = "ExpressionParser_IncompatibleOperands";
	public const string ExpressionParser_InvalidCharacter = "ExpressionParser_InvalidCharacter";
	public const string ExpressionParser_InvalidCharacterLiteral = "ExpressionParser_InvalidCharacterLiteral";
	public const string ExpressionParser_InvalidIndex = "ExpressionParser_InvalidIndex";
	public const string ExpressionParser_InvalidIntegerLiteral = "ExpressionParser_InvalidIntegerLiteral";
	public const string ExpressionParser_InvalidRealLiteral = "ExpressionParser_InvalidRealLiteral";
	public const string ExpressionParser_MethodIsVoid = "ExpressionParser_MethodIsVoid";
	public const string ExpressionParser_MethodsAreInaccessible = "ExpressionParser_MethodsAreInaccessible";
	public const string ExpressionParser_MissingAsClause = "ExpressionParser_MissingAsClause";
	public const string ExpressionParser_NeitherTypeConvertsToOther = "ExpressionParser_NeitherTypeConvertsToOther";
	public const string ExpressionParser_NoApplicableAggregate = "ExpressionParser_NoApplicableAggregate";
	public const string ExpressionParser_NoApplicableIndexer = "ExpressionParser_NoApplicableIndexer";
	public const string ExpressionParser_NoApplicableMethod = "ExpressionParser_NoApplicableMethod";
	public const string ExpressionParser_NoItInScope = "ExpressionParser_NoItInScope";
	public const string ExpressionParser_NoMatchingConstructor = "ExpressionParser_NoMatchingConstructor";
	public const string ExpressionParser_OpenParenExpected = "ExpressionParser_OpenParenExpected";
	public const string ExpressionParser_SyntaxError = "ExpressionParser_SyntaxError";
	public const string ExpressionParser_TypeHasNoNullableForm = "ExpressionParser_TypeHasNoNullableForm";
	public const string ExpressionParser_UnknownIdentifier = "ExpressionParser_UnknownIdentifier";
	public const string ExpressionParser_UnknownPropertyOrField = "ExpressionParser_UnknownPropertyOrField";
	public const string ExpressionParser_UnterminatedStringLiteral = "ExpressionParser_UnterminatedStringLiteral";
	public const string Expressions_DataFieldRequired = "Expressions_DataFieldRequired";
	public const string ExtenderControl_TargetControlDifferentUpdatePanel = "ExtenderControl_TargetControlDifferentUpdatePanel";
	public const string ExtenderControl_TargetControlIDEmpty = "ExtenderControl_TargetControlIDEmpty";
	public const string ExtenderControl_TargetControlIDInvalid = "ExtenderControl_TargetControlIDInvalid";
	public const string JSON_ArrayTypeNotSupported = "JSON_ArrayTypeNotSupported";
	public const string JSON_BadEscape = "JSON_BadEscape";
	public const string JSON_CannotConvertObjectToType = "JSON_CannotConvertObjectToType";
	public const string JSON_CannotCreateListType = "JSON_CannotCreateListType";
	public const string JSON_CannotSerializeMemberGeneric = "JSON_CannotSerializeMemberGeneric";
	public const string JSON_CircularReference = "JSON_CircularReference";
	public const string JSON_DepthLimitExceeded = "JSON_DepthLimitExceeded";
	public const string JSON_DeserializerTypeMismatch = "JSON_DeserializerTypeMismatch";
	public const string JSON_DictionaryTypeNotSupported = "JSON_DictionaryTypeNotSupported";
	public const string JSON_ExpectedOpenBrace = "JSON_ExpectedOpenBrace";
	public const string JSON_IllegalPrimitive = "JSON_IllegalPrimitive";
	public const string JSON_InvalidArrayEnd = "JSON_InvalidArrayEnd";
	public const string JSON_InvalidArrayExpectComma = "JSON_InvalidArrayExpectComma";
	public const string JSON_InvalidArrayExtraComma = "JSON_InvalidArrayExtraComma";
	public const string JSON_InvalidArrayStart = "JSON_InvalidArrayStart";
	public const string JSON_InvalidEnumType = "JSON_InvalidEnumType";
	public const string JSON_InvalidMaxJsonLength = "JSON_InvalidMaxJsonLength";
	public const string JSON_InvalidMemberName = "JSON_InvalidMemberName";
	public const string JSON_InvalidObject = "JSON_InvalidObject";
	public const string JSON_InvalidRecursionLimit = "JSON_InvalidRecursionLimit";
	public const string JSON_MaxJsonLengthExceeded = "JSON_MaxJsonLengthExceeded";
	public const string JSON_NoConstructor = "JSON_NoConstructor";
	public const string JSON_StringNotQuoted = "JSON_StringNotQuoted";
	public const string JSON_UnterminatedString = "JSON_UnterminatedString";
	public const string JSON_ValueTypeCannotBeNull = "JSON_ValueTypeCannotBeNull";
	public const string LinqDataSource_InvalidViewName = "LinqDataSource_InvalidViewName";
	public const string LinqDataSourceValidationException_ValidationFailed = "LinqDataSourceValidationException_ValidationFailed";
	public const string LinqDataSourceView_CannotConvertType = "LinqDataSourceView_CannotConvertType";
	public const string LinqDataSourceView_ContextTypeNameChanged = "LinqDataSourceView_ContextTypeNameChanged";
	public const string LinqDataSourceView_ContextTypeNameNotFound = "LinqDataSourceView_ContextTypeNameNotFound";
	public const string LinqDataSourceView_ContextTypeNameNotSpecified = "LinqDataSourceView_ContextTypeNameNotSpecified";
	public const string LinqDataSourceView_DeleteNotSupported = "LinqDataSourceView_DeleteNotSupported";
	public const string LinqDataSourceView_EnableObjectTrackingChanged = "LinqDataSourceView_EnableObjectTrackingChanged";
	public const string LinqDataSourceView_GroupByNotSupportedOnEdit = "LinqDataSourceView_GroupByNotSupportedOnEdit";
	public const string LinqDataSourceView_InsertNotSupported = "LinqDataSourceView_InsertNotSupported";
	public const string LinqDataSourceView_InsertRequiresValues = "LinqDataSourceView_InsertRequiresValues";
	public const string LinqDataSourceView_InvalidContextType = "LinqDataSourceView_InvalidContextType";
	public const string LinqDataSourceView_InvalidOrderByFieldName = "LinqDataSourceView_InvalidOrderByFieldName";
	public const string LinqDataSourceView_InvalidParameterName = "LinqDataSourceView_InvalidParameterName";
	public const string LinqDataSourceView_InvalidTablePropertyType = "LinqDataSourceView_InvalidTablePropertyType";
	public const string LinqDataSourceView_OrderByAlreadySpecified = "LinqDataSourceView_OrderByAlreadySpecified";
	public const string LinqDataSourceView_OrderGroupsByRequiresGroupBy = "LinqDataSourceView_OrderGroupsByRequiresGroupBy";
	public const string LinqDataSourceView_OriginalValuesNotFound = "LinqDataSourceView_OriginalValuesNotFound";
	public const string LinqDataSourceView_PagingNotHandled = "LinqDataSourceView_PagingNotHandled";
	public const string LinqDataSourceView_ParametersMustBeNamed = "LinqDataSourceView_ParametersMustBeNamed";
	public const string LinqDataSourceView_SelectNewNotSupportedOnEdit = "LinqDataSourceView_SelectNewNotSupportedOnEdit";
	public const string LinqDataSourceView_TableCannotBeStatic = "LinqDataSourceView_TableCannotBeStatic";
	public const string LinqDataSourceView_TableNameChanged = "LinqDataSourceView_TableNameChanged";
	public const string LinqDataSourceView_TableNameNotFound = "LinqDataSourceView_TableNameNotFound";
	public const string LinqDataSourceView_TableNameNotSpecified = "LinqDataSourceView_TableNameNotSpecified";
	public const string LinqDataSourceView_UpdateNotSupported = "LinqDataSourceView_UpdateNotSupported";
	public const string LinqDataSourceView_ValidationFailed = "LinqDataSourceView_ValidationFailed";
	public const string LinqDataSourceView_WhereAlreadySpecified = "LinqDataSourceView_WhereAlreadySpecified";
	public const string ListView_ContainerNameMustNotBeEmpty = "ListView_ContainerNameMustNotBeEmpty";
	public const string ListView_DataKeyNamesMustBeSpecified = "ListView_DataKeyNamesMustBeSpecified";
	public const string ListView_DataSourceDoesntSupportPaging = "ListView_DataSourceDoesntSupportPaging";
	public const string ListView_DataSourceMustBeCollectionWhenNotDataBinding = "ListView_DataSourceMustBeCollectionWhenNotDataBinding";
	public const string ListView_GroupItemCountNoGroupTemplate = "ListView_GroupItemCountNoGroupTemplate";
	public const string ListView_InsertTemplateRequired = "ListView_InsertTemplateRequired";
	public const string ListView_InvalidCancel = "ListView_InvalidCancel";
	public const string ListView_InvalidCommand = "ListView_InvalidCommand";
	public const string ListView_InvalidDelete = "ListView_InvalidDelete";
	public const string ListView_InvalidEdit = "ListView_InvalidEdit";
	public const string ListView_InvalidInsert = "ListView_InvalidInsert";
	public const string ListView_InvalidSelect = "ListView_InvalidSelect";
	public const string ListView_InvalidUpdate = "ListView_InvalidUpdate";
	public const string ListView_ItemsNotDataItems = "ListView_ItemsNotDataItems";
	public const string ListView_ItemTemplateRequired = "ListView_ItemTemplateRequired";
	public const string ListView_Missing_VirtualItemCount = "ListView_Missing_VirtualItemCount";
	public const string ListView_NeedICollectionOrTotalRowCount = "ListView_NeedICollectionOrTotalRowCount";
	public const string ListView_NoGroupPlaceholder = "ListView_NoGroupPlaceholder";
	public const string ListView_NoInsertItem = "ListView_NoInsertItem";
	public const string ListView_NoItemPlaceholder = "ListView_NoItemPlaceholder";
	public const string ListView_NullView = "ListView_NullView";
	public const string ListViewPagedDataSource_CannotGetCount = "ListViewPagedDataSource_CannotGetCount";
	public const string ListViewPagedDataSource_EnumeratorMoveNextNotCalled = "ListViewPagedDataSource_EnumeratorMoveNextNotCalled";
	public const string ListView_PersistedSelectionRequiresDataKeysNames = "ListView_PersistedSelectionRequiresDataKeysNames";
	public const string ListView_StyleNotSupported = "ListView_StyleNotSupported";
	public const string ListView_StylePropertiesNotSupported = "ListView_StylePropertiesNotSupported";
	public const string ListView_UnhandledEvent = "ListView_UnhandledEvent";
	public const string MethodExpression_ChangingTheReturnTypeIsNotAllowed = "MethodExpression_ChangingTheReturnTypeIsNotAllowed";
	public const string MethodExpression_DataSourceMustBeIDynamicDataSource = "MethodExpression_DataSourceMustBeIDynamicDataSource";
	public const string MethodExpression_FirstParamterMustBeCorrectType = "MethodExpression_FirstParamterMustBeCorrectType";
	public const string MethodExpression_MethodMustBeStatic = "MethodExpression_MethodMustBeStatic";
	public const string MethodExpression_MethodNameMustBeSpecified = "MethodExpression_MethodNameMustBeSpecified";
	public const string MethodExpression_MethodNotFound = "MethodExpression_MethodNotFound";
	public const string MethodExpression_ParameterNotFound = "MethodExpression_ParameterNotFound";
	public const string NextPrevPagerField_DefaultFirstPageText = "NextPrevPagerField_DefaultFirstPageText";
	public const string NextPrevPagerField_DefaultLastPageText = "NextPrevPagerField_DefaultLastPageText";
	public const string NextPrevPagerField_DefaultNextPageText = "NextPrevPagerField_DefaultNextPageText";
	public const string NextPrevPagerField_DefaultPreviousPageText = "NextPrevPagerField_DefaultPreviousPageText";
	public const string NumericPagerField_DefaultNextPageText = "NumericPagerField_DefaultNextPageText";
	public const string NumericPagerField_DefaultPreviousPageText = "NumericPagerField_DefaultPreviousPageText";
	public const string OfTypeExpression_CannotFindType = "OfTypeExpression_CannotFindType";
	public const string OfTypeExpression_TypeNameNotSpecified = "OfTypeExpression_TypeNameNotSpecified";
	public const string PageRequestManager_RegisterDataItemInNonAsyncRequest = "PageRequestManager_RegisterDataItemInNonAsyncRequest";
	public const string PageRequestManager_RegisterDataItemTwice = "PageRequestManager_RegisterDataItemTwice";
	public const string PagerFieldCollection_InvalidType = "PagerFieldCollection_InvalidType";
	public const string PagerFieldCollection_InvalidTypeIndex = "PagerFieldCollection_InvalidTypeIndex";
	public const string ParseException_ParseExceptionFormat = "ParseException_ParseExceptionFormat";
	public const string ProfileServiceManager_LoadProperitesWithNonDefaultPath = "ProfileServiceManager_LoadProperitesWithNonDefaultPath";
	public const string ProxyGenerator_UnsupportedType = "ProxyGenerator_UnsupportedType";
	public const string ProxyHelper_BadStatusCode = "ProxyHelper_BadStatusCode";
	public const string QueryExtender_DataSourceMustBeIQueryableDataSource = "QueryExtender_DataSourceMustBeIQueryableDataSource";
	public const string RangeExpression_MaximumValueRequired = "RangeExpression_MaximumValueRequired";
	public const string RangeExpression_MinimumValueRequired = "RangeExpression_MinimumValueRequired";
	public const string RangeExpression_RangeTypeMustBeSpecified = "RangeExpression_RangeTypeMustBeSpecified";
	public const string RoleServiceManager_LoadRolesWithNonDefaultPath = "RoleServiceManager_LoadRolesWithNonDefaultPath";
	public const string RoleService_RoleProviderNotFound = "RoleService_RoleProviderNotFound";
	public const string RoleService_RolesFeatureNotEnabled = "RoleService_RolesFeatureNotEnabled";
	public const string ScriptControlDescriptor_IDNotSettable = "ScriptControlDescriptor_IDNotSettable";
	public const string ScriptControlManager_ExtenderControlNotRegistered = "ScriptControlManager_ExtenderControlNotRegistered";
	public const string ScriptControlManager_NoTargetControlTypes = "ScriptControlManager_NoTargetControlTypes";
	public const string ScriptControlManager_RegisterExtenderControlTooEarly = "ScriptControlManager_RegisterExtenderControlTooEarly";
	public const string ScriptControlManager_RegisterExtenderControlTooLate = "ScriptControlManager_RegisterExtenderControlTooLate";
	public const string ScriptControlManager_RegisterScriptControlTooEarly = "ScriptControlManager_RegisterScriptControlTooEarly";
	public const string ScriptControlManager_RegisterScriptControlTooLate = "ScriptControlManager_RegisterScriptControlTooLate";
	public const string ScriptControlManager_ScriptControlNotRegistered = "ScriptControlManager_ScriptControlNotRegistered";
	public const string ScriptControlManager_TargetControlTypeInvalid = "ScriptControlManager_TargetControlTypeInvalid";
	public const string ScriptManager_AsyncPostBackNotInPartialRenderingMode = "ScriptManager_AsyncPostBackNotInPartialRenderingMode";
	public const string ScriptManager_CannotAddHistoryPointOutsideOfAsyncPostBack = "ScriptManager_CannotAddHistoryPointOutsideOfAsyncPostBack";
	public const string ScriptManager_CannotAddHistoryPointWithHistoryDisabled = "ScriptManager_CannotAddHistoryPointWithHistoryDisabled";
	public const string ScriptManager_CannotChangeAjaxFrameworkMode = "ScriptManager_CannotChangeAjaxFrameworkMode";
	public const string ScriptManager_CannotChangeEnableCdn = "ScriptManager_CannotChangeEnableCdn";
	public const string ScriptManager_CannotChangeEnableCdnFallback = "ScriptManager_CannotChangeEnableCdnFallback";
	public const string ScriptManager_CannotChangeEnableHistory = "ScriptManager_CannotChangeEnableHistory";
	public const string ScriptManager_CannotChangeEnablePartialRendering = "ScriptManager_CannotChangeEnablePartialRendering";
	public const string ScriptManager_CannotChangeEnableScriptGlobalization = "ScriptManager_CannotChangeEnableScriptGlobalization";
	public const string ScriptManager_CannotChangeSupportsPartialRendering = "ScriptManager_CannotChangeSupportsPartialRendering";
	public const string ScriptManager_CannotRegisterBothPostBacks = "ScriptManager_CannotRegisterBothPostBacks";
	public const string ScriptManager_CannotRegisterScriptInMultipleCompositeReferences = "ScriptManager_CannotRegisterScriptInMultipleCompositeReferences";
	public const string ScriptManager_CannotSetSupportsPartialRenderingWhenDisabled = "ScriptManager_CannotSetSupportsPartialRenderingWhenDisabled";
	public const string ScriptManager_FrameworkFailedToLoad = "ScriptManager_FrameworkFailedToLoad";
	public const string ScriptManager_InvalidControlRegistration = "ScriptManager_InvalidControlRegistration";
	public const string ScriptManager_MustHaveGreaterVersion = "ScriptManager_MustHaveGreaterVersion";
	public const string ScriptManager_OnlyOneScriptManager = "ScriptManager_OnlyOneScriptManager";
	public const string ScriptManager_PageUntitled = "ScriptManager_PageUntitled";
	public const string ScriptManager_UpdatePanelNotRegistered = "ScriptManager_UpdatePanelNotRegistered";
	public const string ScriptReference_AssemblyRequiresName = "ScriptReference_AssemblyRequiresName";
	public const string ScriptReference_InvalidReleaseScriptName = "ScriptReference_InvalidReleaseScriptName";
	public const string ScriptReference_InvalidReleaseScriptPath = "ScriptReference_InvalidReleaseScriptPath";
	public const string ScriptReference_NameAndPathCannotBeEmpty = "ScriptReference_NameAndPathCannotBeEmpty";
	public const string ScriptReference_ResourceRequiresAjaxAssembly = "ScriptReference_ResourceRequiresAjaxAssembly";
	public const string ScriptRegistrationManager_ControlNotOnPage = "ScriptRegistrationManager_ControlNotOnPage";
	public const string ScriptRegistrationManager_InvalidChars = "ScriptRegistrationManager_InvalidChars";
	public const string ScriptRegistrationManager_NoCloseTag = "ScriptRegistrationManager_NoCloseTag";
	public const string ScriptRegistrationManager_NoTags = "ScriptRegistrationManager_NoTags";
	public const string ScriptResourceDefinition_InvalidPath = "ScriptResourceDefinition_InvalidPath";
	public const string ScriptResourceDefinition_NameAndPathCannotBeEmpty = "ScriptResourceDefinition_NameAndPathCannotBeEmpty";
	public const string ScriptResourceHandler_DuplicateScriptResources = "ScriptResourceHandler_DuplicateScriptResources";
	public const string ScriptResourceHandler_InvalidRequest = "ScriptResourceHandler_InvalidRequest";
	public const string ScriptResourceHandler_ResourceUrlTooLong = "ScriptResourceHandler_ResourceUrlTooLong";
	public const string ScriptResourceHandler_TypeNameMismatch = "ScriptResourceHandler_TypeNameMismatch";
	public const string ScriptResourceHandler_UnknownResource = "ScriptResourceHandler_UnknownResource";
	public const string SearchExpression_ParameterRequired = "SearchExpression_ParameterRequired";
	public const string ServiceReference_PathCannotBeEmpty = "ServiceReference_PathCannotBeEmpty";
	public const string ServiceUriNotFound = "ServiceUriNotFound";
	public const string SqlHelper_SqlEverywhereNotInstalled = "SqlHelper_SqlEverywhereNotInstalled";
	public const string TemplatePagerField_UnhandledEvent = "TemplatePagerField_UnhandledEvent";
	public const string Timer_IntervalMustBeGreaterThanZero = "Timer_IntervalMustBeGreaterThanZero";
	public const string UnhandledExceptionEventLogMessage = "UnhandledExceptionEventLogMessage";
	public const string UpdatePanel_CannotModifyControlCollection = "UpdatePanel_CannotModifyControlCollection";
	public const string UpdatePanel_CannotSetContentTemplate = "UpdatePanel_CannotSetContentTemplate";
	public const string UpdatePanel_ChildrenTriggersAndUpdateAlways = "UpdatePanel_ChildrenTriggersAndUpdateAlways";
	public const string UpdatePanelControlTrigger_ControlNotFound = "UpdatePanelControlTrigger_ControlNotFound";
	public const string UpdatePanelControlTrigger_NoControlID = "UpdatePanelControlTrigger_NoControlID";
	public const string UpdatePanel_SetPartialRenderingModeCalledOnce = "UpdatePanel_SetPartialRenderingModeCalledOnce";
	public const string UpdatePanel_UpdateConditional = "UpdatePanel_UpdateConditional";
	public const string UpdatePanel_UpdateTooLate = "UpdatePanel_UpdateTooLate";
	public const string UpdateProgress_DisplayAfterInvalid = "UpdateProgress_DisplayAfterInvalid";
	public const string UpdateProgress_NoUpdatePanel = "UpdateProgress_NoUpdatePanel";
	public const string UserIsNotAuthenticated = "UserIsNotAuthenticated";
	public const string WebResourceUtil_AssemblyDoesNotContainDebugWebResource = "WebResourceUtil_AssemblyDoesNotContainDebugWebResource";
	public const string WebResourceUtil_AssemblyDoesNotContainEmbeddedResource = "WebResourceUtil_AssemblyDoesNotContainEmbeddedResource";
	public const string WebResourceUtil_AssemblyDoesNotContainReleaseWebResource = "WebResourceUtil_AssemblyDoesNotContainReleaseWebResource";
	public const string WebResourceUtil_SystemWebExtensionsDoesNotContainReleaseWebResource = "WebResourceUtil_SystemWebExtensionsDoesNotContainReleaseWebResource";
	public const string WebService_Error = "WebService_Error";
	public const string WebService_InvalidGenerateScriptType = "WebService_InvalidGenerateScriptType";
	public const string WebService_InvalidInlineVirtualPath = "WebService_InvalidInlineVirtualPath";
	public const string WebService_InvalidVerbRequest = "WebService_InvalidVerbRequest";
	public const string WebService_InvalidWebServiceCall = "WebService_InvalidWebServiceCall";
	public const string WebService_InvalidXmlReturnType = "WebService_InvalidXmlReturnType";
	public const string WebService_MissingArg = "WebService_MissingArg";
	public const string WebService_NoScriptServiceAttribute = "WebService_NoScriptServiceAttribute";
	public const string WebService_NoWebServiceData = "WebService_NoWebServiceData";
	public const string WebService_NoWebServiceDataInlineScript = "WebService_NoWebServiceDataInlineScript";
	public const string WebService_RedirectError = "WebService_RedirectError";
	public const string WebService_UnknownWebMethod = "WebService_UnknownWebMethod";
}

}
