TOP=$(realpath $(CURDIR)/../../..)
-include $(TOP)/sdks/Make.config
include $(TOP)/sdks/versions.mk
include $(TOP)/sdks/paths.mk

all: build-dev build-sim

CC = $(XCODE_DIR)/Toolchains/XcodeDefault.xctoolchain/usr/bin/clang
SIM_SYSROOT = $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/SDKs/iPhoneSimulator.sdk
SIM_ARCH = x86_64
SIM_CFLAGS = \
	-isysroot $(SIM_SYSROOT) \
	-iframework $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Frameworks \
	-std=gnu11 \
	-fobjc-arc \
	-fobjc-weak \
	-g

SIM_LDFLAGS = \
	-bundle \
	-isysroot $(SIM_SYSROOT) \
	-framework XCTest \
	-fobjc-arc \
	-fobjc-link-runtime \
	-L$(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/usr/lib \
	-F$(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Frameworks \
	-Xlinker -rpath -Xlinker @executable_path/Frameworks \
	-Xlinker -rpath -Xlinker @loader_path/Frameworks \
	-Xlinker -export_dynamic \
	-Xlinker -no_deduplicate

sim-test.o: test.m
	$(ENV) $(CC) -target $(SIM_ARCH)-apple-ios10.1-simulator $(SIM_CFLAGS) -c -o $@ $^

sim-test: sim-test.o
	$(ENV) $(CC) -target $(SIM_ARCH)-apple-ios10.1-simulator $(SIM_LDFLAGS) -o $@ $^


DEV_ARCH = arm64
DEV_SYSROOT = $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS.sdk/
DEV_CFLAGS = \
	-isysroot $(DEV_SYSROOT) \
	-iframework $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Frameworks \
	-std=gnu11 \
	-fobjc-arc \
	-fobjc-weak \
	-g

DEV_LDFLAGS = \
	-bundle \
	-isysroot $(DEV_SYSROOT) \
	-framework XCTest \
	-fobjc-arc \
	-fobjc-link-runtime \
	-L$(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/usr/lib \
	-F$(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Frameworks \
	-Xlinker -rpath -Xlinker @executable_path/Frameworks \
	-Xlinker -rpath -Xlinker @loader_path/Frameworks \
	-Xlinker -export_dynamic \
	-Xlinker -no_deduplicate

dev-test.o: test.m
	$(ENV) $(CC) -target $(DEV_ARCH)-apple-ios10.1 $(DEV_CFLAGS) -c -o $@ $^

dev-test: dev-test.o
	$(ENV) $(CC) -target $(DEV_ARCH)-apple-ios10.1 $(DEV_LDFLAGS) -o $@ $^

build-sim: sim-test
	mkdir -p $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app
	sed -e 's,WRAPPEDPRODUCTNAME,testcloudUITests-Runner,' -e 's,WRAPPEDPRODUCTBUNDLEIDENTIFIER,com.xamarin.mono.ios.testcloud.xctrunner,' $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Xcode/Agents/XCTRunner.app/Info.plist > $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Info.plist
	cp $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Xcode/Agents/XCTRunner.app/PkgInfo $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/PkgInfo
	cp $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Xcode/Agents/XCTRunner.app/XCTRunner $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/testcloudUITests-Runner
	mkdir -p $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Frameworks
	cp $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/usr/lib/libXCTestSwiftSupport.dylib $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Frameworks
	cp -R $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/PrivateFrameworks/XCTAutomationSupport.framework $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Frameworks
	cp -R $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Frameworks/XCTest.framework $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Frameworks
	rm -rf $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Frameworks/*.framework/Headers
	rm -rf $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Frameworks/*.framework/Modules
	mkdir -p $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Plugins/testcloud.xctest
	cp sim-test $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Plugins/testcloud.xctest/testcloud
	cp Info.plist $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Plugins/testcloud.xctest/Info.plist
	plutil -convert binary1 $(TOP)/sdks/ios/bin/ios-sim/testcloudUITests-Runner.app/Plugins/testcloud.xctest/Info.plist

build-dev: dev-test
	mkdir -p $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app
	sed -e 's,WRAPPEDPRODUCTNAME,testcloudUITests-Runner,' -e 's,WRAPPEDPRODUCTBUNDLEIDENTIFIER,com.xamarin.mono.ios.testcloud.xctrunner,' $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Xcode/Agents/XCTRunner.app/Info.plist > $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Info.plist
	cp $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Xcode/Agents/XCTRunner.app/PkgInfo $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/PkgInfo
	cp $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Xcode/Agents/XCTRunner.app/XCTRunner $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/testcloudUITests-Runner
	mkdir -p $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Frameworks
	cp $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/usr/lib/libXCTestSwiftSupport.dylib $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Frameworks
	cp -R $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/PrivateFrameworks/XCTAutomationSupport.framework $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Frameworks
	cp -R $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Frameworks/XCTest.framework $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Frameworks
	rm -rf $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Frameworks/*.framework/Headers
	rm -rf $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Frameworks/*.framework/Modules
	mkdir -p $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Plugins/testcloud.xctest
	cp dev-test $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Plugins/testcloud.xctest/testcloud
	$(XCODE_DIR)/Toolchains/XcodeDefault.xctoolchain/usr/bin/dsymutil $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Plugins/testcloud.xctest/testcloud -o $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Plugins/testcloud.xctest.dSYM
	cp Info.plist $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Plugins/testcloud.xctest/Info.plist
	plutil -convert binary1 $(TOP)/sdks/ios/bin/ios-dev/testcloudUITests-Runner.app/Plugins/testcloud.xctest/Info.plist

clean:
	$(RM) -rf dev-test sim-test *.o *.a
