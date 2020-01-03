//
//  test.m
//

#import <XCTest/XCTest.h>

@interface UITest : XCTestCase

@end


@implementation UITest

- (void) runTestsForAssembly:(NSString*)testAssembly {
	XCUIApplication *app = [[XCUIApplication alloc] initWithBundleIdentifier: @"com.xamarin.mono.ios.test-AllTests"];
	app.launchArguments = [NSArray arrayWithObjects:@"test-runner.exe", testAssembly, nil];
	[app launch];

	XCUIElement* summaryLabel = app.staticTexts[@"SummaryLabel"];

	NSPredicate *hasSummaryText = [NSPredicate predicateWithFormat:@"label CONTAINS[c] 'Summary: '"];
	[self expectationForPredicate:hasSummaryText evaluatedWithObject:summaryLabel handler:nil];
	[self waitForExpectationsWithTimeout:600 handler:nil];  // wait 10 minutes for test run to complete

	XCTAssertEqualObjects (@"Summary: Succeeded", [summaryLabel.label substringToIndex:18]);
}

- (void)setUp { self.continueAfterFailure = NO; }

- (void)testMonoRuntimeTests                     { [self runTestsForAssembly: @"monotouch_Mono.Runtime.Tests_test.dll"]; }
- (void)testCorlib                               { [self runTestsForAssembly: @"monotouch_corlib_test.dll"]; }
- (void)testSystem                               { [self runTestsForAssembly: @"monotouch_System_test.dll"]; }
- (void)testSystemXml                            { [self runTestsForAssembly: @"monotouch_System.Xml_test.dll"]; }
- (void)testSystemCore                           { [self runTestsForAssembly: @"monotouch_System.Core_test.dll"]; }
- (void)testSystemData                           { [self runTestsForAssembly: @"monotouch_System.Data_test.dll"]; }
- (void)testSystemNumerics                       { [self runTestsForAssembly: @"monotouch_System.Numerics_test.dll"]; }
- (void)testSystemNetHttp                        { [self runTestsForAssembly: @"monotouch_System.Net.Http_test.dll"]; }
- (void)testSystemRuntimeSerialization           { [self runTestsForAssembly: @"monotouch_System.Runtime.Serialization_test.dll"]; }
- (void)testSystemTransactions                   { [self runTestsForAssembly: @"monotouch_System.Transactions_test.dll"]; }
- (void)testSystemIOCompression                  { [self runTestsForAssembly: @"monotouch_System.IO.Compression_test.dll"]; }
- (void)testSystemIOCompressionFileSystem        { [self runTestsForAssembly: @"monotouch_System.IO.Compression.FileSystem_test.dll"]; }
- (void)testSystemJson                           { [self runTestsForAssembly: @"monotouch_System.Json_test.dll"]; }
- (void)testSystemComponentModelDataAnnotations  { [self runTestsForAssembly: @"monotouch_System.ComponentModel.DataAnnotations_test.dll"]; }
- (void)testSystemSecurity                       { [self runTestsForAssembly: @"monotouch_System.Security_test.dll"]; }
- (void)testSystemXmlLinq                        { [self runTestsForAssembly: @"monotouch_System.Xml.Linq_test.dll"]; }
- (void)testSystemServiceModelWeb                { [self runTestsForAssembly: @"monotouch_System.ServiceModel.Web_test.dll"]; }
- (void)testSystemWebServices                    { [self runTestsForAssembly: @"monotouch_System.Web.Services_test.dll"]; }
- (void)testMonoCSharp                           { [self runTestsForAssembly: @"monotouch_Mono.CSharp_test.dll"]; }
- (void)testMonoDataSqlite                       { [self runTestsForAssembly: @"monotouch_Mono.Data.Sqlite_test.dll"]; }
- (void)testMonoDataTds                          { [self runTestsForAssembly: @"monotouch_Mono.Data.Tds_test.dll"]; }
- (void)testMonoSecurity                         { [self runTestsForAssembly: @"monotouch_Mono.Security_test.dll"]; }
@end
