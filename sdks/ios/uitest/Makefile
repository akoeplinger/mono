TOP=$(realpath $(CURDIR)/../../..)
-include $(TOP)/sdks/Make.config
include $(TOP)/sdks/versions.mk
include $(TOP)/sdks/paths.mk

all: build-dev build-sim

CC = $(XCODE_DIR)/Toolchains/XcodeDefault.xctoolchain/usr/bin/clang
SIM_SYSROOT = $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/SDKs/iPhoneSimulator.sdk
SIM_ARCH = x86_64
SIM_CFLAGS = \
	-x objective-c \
	-target $(SIM_ARCH)-apple-ios10.1-simulator \
	-isysroot $(SIM_SYSROOT) \
	-iframework $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Frameworks \
	-std=gnu11 \
	-fobjc-arc \
	-fobjc-weak \
	-fmodules \
	-gmodules \
	-O0 \
	-fno-common \
	-fstrict-aliasing \
	-DOBJC_OLD_DISPATCH_PROTOTYPES=0 \
	-g

SIM_LDFLAGS = \
	-target $(SIM_ARCH)-apple-ios10.1-simulator \
	-bundle \
	-isysroot $(SIM_SYSROOT) \
	-L$(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/usr/lib \
	-F$(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Frameworks \
	-Xlinker -rpath -Xlinker @executable_path/Frameworks \
	-Xlinker -rpath -Xlinker @loader_path/Frameworks \
	-dead_strip \
	-Xlinker -export_dynamic \
	-Xlinker -no_deduplicate \
	-fobjc-arc \
	-fobjc-link-runtime \
	-framework XCTest

sim-test.o: test.m Makefile
	$(ENV) $(CC) $(SIM_CFLAGS) -o $@ -c test.m

sim-test: sim-test.o Makefile
	$(ENV) $(CC) $(SIM_LDFLAGS) -o $@ sim-test.o


DEV_ARCH = arm64
DEV_SYSROOT = $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS13.2.sdk
DEV_CFLAGS = \
	-x objective-c \
	-target $(DEV_ARCH)-apple-ios10.1 \
	-isysroot $(DEV_SYSROOT) \
	-iframework $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Frameworks \
	-std=gnu11 \
	-fobjc-arc \
	-fobjc-weak \
	-fmodules \
	-gmodules \
	-O0 \
	-fno-common \
	-fstrict-aliasing \
	-DOBJC_OLD_DISPATCH_PROTOTYPES=0 \
	-g

DEV_CFLAGS += \
	-fmessage-length=359 \
	-fdiagnostics-show-note-include-stack \
	-fmacro-backtrace-limit=0 \
	-fcolor-diagnostics \
	-Wnon-modular-include-in-framework-module \
	-Werror=non-modular-include-in-framework-module \
	-Wno-trigraphs \
	-fpascal-strings \
	-Wno-missing-field-initializers \
	-Wno-missing-prototypes \
	-Werror=return-type \
	-Wdocumentation \
	-Wunreachable-code \
	-Wno-implicit-atomic-properties \
	-Werror=deprecated-objc-isa-usage \
	-Wno-objc-interface-ivars \
	-Werror=objc-root-class \
	-Wno-arc-repeated-use-of-weak \
	-Wimplicit-retain-self \
	-Wduplicate-method-match \
	-Wno-missing-braces \
	-Wparentheses \
	-Wswitch \
	-Wunused-function \
	-Wno-unused-label \
	-Wno-unused-parameter \
	-Wunused-variable \
	-Wunused-value \
	-Wempty-body \
	-Wuninitialized \
	-Wconditional-uninitialized \
	-Wno-unknown-pragmas \
	-Wno-shadow \
	-Wno-four-char-constants \
	-Wno-conversion \
	-Wconstant-conversion \
	-Wint-conversion \
	-Wbool-conversion \
	-Wenum-conversion \
	-Wno-float-conversion \
	-Wnon-literal-null-conversion \
	-Wobjc-literal-conversion \
	-Wshorten-64-to-32 \
	-Wpointer-sign \
	-Wno-newline-eof \
	-Wno-selector \
	-Wno-strict-selector-match \
	-Wundeclared-selector \
	-Wdeprecated-implementations \
	-DDEBUG=1 \
	-Wprotocol \
	-Wdeprecated-declarations \
	-Wno-sign-conversion \
	-Winfinite-recursion \
	-Wcomma \
	-Wblock-capture-autoreleasing \
	-Wstrict-prototypes \
	-Wno-semicolon-before-method-body \
	-Wunguarded-availability



DEV_LDFLAGS = \
	-target $(DEV_ARCH)-apple-ios10.1 \
	-bundle \
	-isysroot $(DEV_SYSROOT) \
	-L$(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/usr/lib \
	-F$(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Frameworks \
	-Xlinker -rpath -Xlinker @executable_path/Frameworks \
	-Xlinker -rpath -Xlinker @loader_path/Frameworks \
	-dead_strip \
	-Xlinker -export_dynamic \
	-Xlinker -no_deduplicate \
	-fobjc-arc \
	-fobjc-link-runtime \
	-framework XCTest

dev-test.o: test.m Makefile
	export LANG=en_US.US-ASCII && $(ENV) $(CC) $(DEV_CFLAGS) -o $@ -c test.m

dev-test: dev-test.o Makefile
	$(ENV) $(CC) $(DEV_LDFLAGS) -o $@ dev-test.o

build-sim: sim-test Info.plist
	mkdir -p $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app
	sed -e 's,WRAPPEDPRODUCTNAME,uitest-Runner,' -e 's,WRAPPEDPRODUCTBUNDLEIDENTIFIER,com.xamarin.mono.ios.uitest.xctrunner,' $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Xcode/Agents/XCTRunner.app/Info.plist > $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Info.plist
	ditto -rsrc $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Xcode/Agents/XCTRunner.app/PkgInfo $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/PkgInfo
	cp $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Xcode/Agents/XCTRunner.app/XCTRunner $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/uitest-Runner
	mkdir -p $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Frameworks
	cp $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/usr/lib/libXCTestSwiftSupport.dylib $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Frameworks
	cp -R $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/PrivateFrameworks/XCTAutomationSupport.framework $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Frameworks
	cp -R $(XCODE_DIR)/Platforms/iPhoneSimulator.platform/Developer/Library/Frameworks/XCTest.framework $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Frameworks
	rm -rf $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Frameworks/*.framework/Headers
	rm -rf $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Frameworks/*.framework/Modules
	mkdir -p $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Plugins/uitest.xctest
	cp sim-test $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Plugins/uitest.xctest/uitest
	cp Info.plist $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Plugins/uitest.xctest/Info.plist
	plutil -convert binary1 $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Plugins/uitest.xctest/Info.plist
	$(XCODE_DIR)/Toolchains/XcodeDefault.xctoolchain/usr/bin/dsymutil $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Plugins/uitest.xctest/uitest -o $(TOP)/sdks/ios/bin/ios-sim/uitest-Runner.app/Plugins/uitest.xctest.dSYM

build-dev: dev-test Info.plist
	mkdir -p $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app
	sed -e 's,WRAPPEDPRODUCTNAME,uitest-Runner,' -e 's,WRAPPEDPRODUCTBUNDLEIDENTIFIER,com.xamarin.mono.ios.uitest.xctrunner,' $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Xcode/Agents/XCTRunner.app/Info.plist > $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Info.plist
	ditto -rsrc $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Xcode/Agents/XCTRunner.app/PkgInfo $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/PkgInfo
	$(XCODE_DIR)/Toolchains/XcodeDefault.xctoolchain/usr/bin/lipo $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Xcode/Agents/XCTRunner.app/XCTRunner -output $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/uitest-Runner -remove arm64e
	mkdir -p $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Frameworks
	cp $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/usr/lib/libXCTestSwiftSupport.dylib $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Frameworks
	cp -R $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/PrivateFrameworks/XCTAutomationSupport.framework $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Frameworks
	cp -R $(XCODE_DIR)/Platforms/iPhoneOS.platform/Developer/Library/Frameworks/XCTest.framework $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Frameworks
	rm -rf $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Frameworks/*.framework/Headers
	rm -rf $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Frameworks/*.framework/Modules
	mkdir -p $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Plugins/uitest.xctest
	cp dev-test $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Plugins/uitest.xctest/uitest
	cp Info.plist $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Plugins/uitest.xctest/Info.plist
	plutil -convert binary1 $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Plugins/uitest.xctest/Info.plist
	$(XCODE_DIR)/Toolchains/XcodeDefault.xctoolchain/usr/bin/dsymutil $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Plugins/uitest.xctest/uitest -o $(TOP)/sdks/ios/bin/ios-dev/uitest-Runner.app/Plugins/uitest.xctest.dSYM

clean:
	$(RM) -rf dev-test sim-test *.o *.a
