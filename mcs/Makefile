thisdir := .

SUBDIRS := build jay mcs class nunit24 ilasm tools tests errors docs packages

# Resgen is corlib specific tool

basic_SUBDIRS := build jay class
build_SUBDIRS := build class class/aot-compiler tools ilasm
monodroid_SUBDIRS := build class
monotouch_SUBDIRS := build class
monotouch_watch_SUBDIRS := build class
monotouch_tv_SUBDIRS := build class
monotouch_runtime_SUBDIRS := build class
monotouch_watch_runtime_SUBDIRS := build class
monotouch_tv_runtime_SUBDIRS := build class
xammac_SUBDIRS := build class
testing_aot_hybrid_SUBDIRS := build class
testing_aot_full_SUBDIRS := build class
binary_reference_assemblies_SUBDIRS := build class
net_4_x_SUBDIRS := build class nunit24 ilasm tools tests errors docs mcs class/aot-compiler packages
xammac_net_4_5_SUBDIRS := build class
xbuild_12_SUBDIRS := build class tools/xbuild
xbuild_14_SUBDIRS := build class tools/xbuild
winaot_SUBDIRS := build class
orbis_SUBDIRS := build class

include build/rules.make

all-recursive $(STD_TARGETS:=-recursive): dir-check platform-check profile-check

.PHONY: all-local $(STD_TARGETS:=-local)
all-local $(STD_TARGETS:=-local):
	@:

dir-check:
	@if [ "$(NO_DIR_CHECK)" = "" -a "$(PROFILE)" != "basic" ]; then $(MAKE) -C ../runtime; fi

# fun specialty targets

PROFILES = net_4_x binary_reference_assemblies xbuild_12 xbuild_14

.PHONY: all-profiles $(STD_TARGETS:=-profiles)
all-profiles $(STD_TARGETS:=-profiles): %-profiles: profiles-do--%
	@:

profiles-do--%:
	$(MAKE) $(PROFILES:%=profile-do--%--$*)

# The % below looks like profile-name--target-name
profile-do--%:
	$(MAKE) PROFILE=$(subst --, ,$*)

# xbuild_12 and xbuild_14 will try to install the same files, so they need
# to be ordered
profile-do--xbuild_14--install: profile-do--xbuild_12--install

# We don't want to run the tests in parallel.  We want behaviour like -k.
profiles-do--run-test:
	ret=:; $(foreach p,$(PROFILES), { $(MAKE) PROFILE=$(p) run-test || ret=false; }; ) $$ret

# Orchestrate the bootstrap here.
_boot_ = all clean install
$(_boot_:%=profile-do--xbuild_14--%):         profile-do--xbuild_14--%:         profile-do--net_4_x--%
$(_boot_:%=profile-do--xbuild_12--%):         profile-do--xbuild_12--%:         profile-do--net_4_x--%
$(_boot_:%=profile-do--binary_reference_assemblies--%):           profile-do--binary_reference_assemblies--%:           profile-do--build--%
$(_boot_:%=profile-do--net_4_x--%):           profile-do--net_4_x--%:           profile-do--build--%
$(_boot_:%=profile-do--monodroid--%):         profile-do--monodroid--%:         profile-do--build--%
$(_boot_:%=profile-do--monotouch--%):         profile-do--monotouch--%:         profile-do--build--%
$(_boot_:%=profile-do--monotouch_watch--%):   profile-do--monotouch_watch--%:   profile-do--build--%
$(_boot_:%=profile-do--monotouch_tv--%):      profile-do--monotouch_tv--%:      profile-do--build--%
$(_boot_:%=profile-do--monotouch_runtime--%):  profile-do--monotouch_runtime--%:  profile-do--build--%
$(_boot_:%=profile-do--monotouch_watch_runtime--%):  profile-do--monotouch_watch_runtime--%:  profile-do--build--%
$(_boot_:%=profile-do--monotouch_tv_runtime--%):     profile-do--monotouch_tv_runtime--%:     profile-do--build--%
$(_boot_:%=profile-do--xammac--%):            profile-do--xammac--%:            profile-do--build--%
$(_boot_:%=profile-do--xammac_net_4_5--%):    profile-do--xammac_net_4_5--%:           profile-do--build--%
$(_boot_:%=profile-do--testing_aot_hybrid--%):        profile-do--testing_aot_hybrid--%:        profile-do--build--%
$(_boot_:%=profile-do--testing_aot_full--%):          profile-do--testing_aot_full--%:          profile-do--build--%
$(_boot_:%=profile-do--winaot--%):              profile-do--winaot--%:              profile-do--build--%
$(_boot_:%=profile-do--orbis--%):              profile-do--orbis--%:              profile-do--build--%
$(_boot_:%=profile-do--build--%):             profile-do--build--%:             profile-do--basic--%

testcorlib:
	@cd class/corlib && $(MAKE) test run-test

compiler-tests:
	$(MAKE) TEST_SUBDIRS="tests errors" run-test-profiles

package := mcs-$(VERSION)

DISTFILES = \
	AUTHORS			\
	COPYING			\
	INSTALL.txt		\
	Makefile		\
	mkinstalldirs		\
	MonoIcon.png		\
	README			\
	ScalableMonoIcon.svg

dist-local: dist-default

csproj-local:

dist-pre:
	rm -rf $(package)
	mkdir $(package)

dist-tarball: dist-pre
	$(MAKE) distdir='$(package)' dist-recursive
	tar cvjf $(package).tar.bz2 $(package)

dist: dist-tarball
	rm -rf $(package)

# the egrep -v is kind of a hack (to get rid of the makefrags)
# but otherwise we have to make dist then make clean which
# is sort of not kosher. And it breaks with DIST_ONLY_SUBDIRS.
#
# We need to set prefix on make so class/System/Makefile can find
# the installed System.Xml to build properly

distcheck: dist-tarball
	rm -rf InstallTest Distcheck-MCS ; \
	mkdir InstallTest ; \
	destdir=`cd InstallTest && pwd` ; \
	mv $(package) Distcheck-MCS ; \
	(cd Distcheck-MCS && \
	    $(MAKE) prefix=$(prefix) && $(MAKE) test && $(MAKE) install DESTDIR="$$destdir" && \
	    $(MAKE) clean && $(MAKE) dist || exit 1) || exit 1 ; \
	mv Distcheck-MCS $(package) ; \
	tar tjf $(package)/$(package).tar.bz2 |sed -e 's,/$$,,' |sort >distdist.list ; \
	rm $(package)/$(package).tar.bz2 ; \
	tar tjf $(package).tar.bz2 |sed -e 's,/$$,,' |sort >before.list ; \
	find $(package) |egrep -v '(makefrag|response)' |sed -e 's,/$$,,' |sort >after.list ; \
	cmp before.list after.list || exit 1 ; \
	cmp before.list distdist.list || exit 1 ; \
	rm -f before.list after.list distdist.list ; \
	rm -rf $(package) InstallTest

# Targets for creating API diffs of the framework

MONO_API_SNAPSHOT_PATH := $(topdir)../external/api-snapshot/
GENAPI := $(MONO_API_SNAPSHOT_PATH)tools/genapi/GenAPI.exe
MONO_API_SNAPSHOT_OUT_PATH ?= $(MONO_API_SNAPSHOT_PATH)profiles/$(PROFILE)/
MONO_API_SNAPSHOT_REF_PATH ?= $(topdir)class/lib/$(PROFILE)/
MONO_API_ASSEMBLIES_IGNORED := $(addprefix $(MONO_API_SNAPSHOT_REF_PATH), Mono.CSharp.dll SystemWebTestShim.dll standalone-runner-support.dll nunit.core.dll nunit.core.extensions.dll nunit.core.interfaces.dll nunit.framework.dll nunit.framework.extensions.dll nunit.mocks.dll nunit.util.dll nunit-console-runner.dll nunitlite.dll $(MONO_API_ASSEMBLIES_IGNORED_ADDITIONAL))
MONO_API_ASSEMBLIES := $(filter-out $(MONO_API_ASSEMBLIES_IGNORED), $(wildcard $(MONO_API_SNAPSHOT_REF_PATH)*.dll)) $(wildcard $(MONO_API_SNAPSHOT_REF_PATH)Facades/*.dll)
MONO_API_ASSEMBLIES_CS := $(MONO_API_ASSEMBLIES:$(MONO_API_SNAPSHOT_REF_PATH)%.dll=$(MONO_API_SNAPSHOT_OUT_PATH)%.cs)

$(MONO_API_SNAPSHOT_OUT_PATH)%.cs: $(MONO_API_SNAPSHOT_REF_PATH)%.dll $(GENAPI) $(MONO_API_SNAPSHOT_PATH)profiles/license-header.txt
	@mkdir -p $(dir $@)
	$(Q) MONO_PATH=$(topdir)class/lib/$(BUILD_TOOLS_PROFILE) $(RUNTIME) $(GENAPI) -libPath:$(MONO_API_SNAPSHOT_REF_PATH),$(MONO_API_SNAPSHOT_REF_PATH)/Facades -out:$(dir $@) -headerFile:$(MONO_API_SNAPSHOT_PATH)profiles/license-header.txt $(GENAPI_ADDITIONAL_ARGS) -assembly:$< || echo "Couldn't process assembly." > $@

mono-api-current: $(MONO_API_ASSEMBLIES_CS)

mono-api-current-clean:
	$(Q) rm -rf "$(MONO_API_SNAPSHOT_OUT_PATH)"

mono-api-diff:
	@echo "Regenerating API snapshot..."
	$(Q) $(MAKE) mono-api-current-clean PROFILE=net_4_x
	$(Q) $(MAKE) mono-api-current-clean PROFILE=monotouch
	$(Q) $(MAKE) mono-api-current-clean PROFILE=monodroid
	$(Q) $(MAKE) mono-api-current PROFILE=net_4_x   GENAPI_ADDITIONAL_ARGS="-assemblyAttributes -typeForwardedTo -assemblyVersion"
	$(Q) $(MAKE) mono-api-current PROFILE=monotouch GENAPI_ADDITIONAL_ARGS="-assemblyAttributes -typeForwardedTo -assemblyVersion"
	$(Q) $(MAKE) mono-api-current PROFILE=monodroid GENAPI_ADDITIONAL_ARGS="-assemblyAttributes -typeForwardedTo -assemblyVersion"
	@echo "Checking public API differences..."
	$(Q) cd $(MONO_API_SNAPSHOT_PATH); git add -A .
	$(Q) cd $(MONO_API_SNAPSHOT_PATH); git diff --no-renames HEAD > $(abspath $(topdir))/temp.patch
	@mkdir -p apidiff
	$(Q) sed -e "/@diffdata@/r temp.patch" -e "/@diffdata@/d" -e "s/@title@/Public API Diff/g" -e "s/@description@/If the changes are intentional, run <code>make -C mcs mono-api-diff<\/code> locally and commit changes in external\/api-snapshot./g" diff.html.in > apidiff/index.html
	$(Q) if [ -s temp.patch ]; then echo "Error: Found public API differences, see mcs/apidiff/index.html. If the changes are intentional, please go to external/api-snapshot and commit them."; rm -f temp.patch; exit 1; else echo "No differences found."; rm -f temp.patch; fi

apidiff/net47-ref/mscorlib.dll:
	@mkdir -p apidiff
	curl -L -o apidiff/net47.zip https://dotnet.myget.org/F/dotnet-core/api/v2/package/Microsoft.TargetingPack.NETFramework.v4.7/1.0.1 && unzip -j apidiff/net47.zip "lib/net47/*" -d apidiff/net47-ref && rm apidiff/net47.zip

net47-net4x-api-diff: apidiff/net47-ref/mscorlib.dll
	@echo "Regenerating .NET 4.7 and Mono net_4_x snapshots..."
	$(Q) rm -rf apidiff/net4x/ apidiff/net47/
	$(Q) $(MAKE) mono-api-current PROFILE=net_4_x MONO_API_SNAPSHOT_OUT_PATH=apidiff/net4x/ MONO_API_ASSEMBLIES_IGNORED_ADDITIONAL="Accessibility.dll System.EnterpriseServices.Thunk.dll System.EnterpriseServices.Wrapper.dll" GENAPI_ADDITIONAL_ARGS="-excludeAttributesList:attrExcl.txt -excludeApiList:apiExcl.txt"
	$(Q) $(MAKE) mono-api-current MONO_API_SNAPSHOT_OUT_PATH=apidiff/net47/ MONO_API_SNAPSHOT_REF_PATH=apidiff/net47-ref/ MONO_API_ASSEMBLIES_IGNORED_ADDITIONAL="Accessibility.dll System.EnterpriseServices.Thunk.dll System.EnterpriseServices.Wrapper.dll" GENAPI_ADDITIONAL_ARGS="-excludeAttributesList:attrExcl.txt -excludeApiList:apiExcl.txt"
	@echo "Computing public API differences..."
	$(Q) diff -u apidiff/net47/ apidiff/net4x/ | sed "s/net4x/net47/g" > temp.patch
	@mkdir -p apidiff
	$(Q) sed -e "/@diffdata@/r temp.patch" -e "/@diffdata@/d" -e "s/@title@/.NET 4.7 vs. Mono net_4_x API Diff/g" -e "s/@description@/These are the differences from .NET 4.7./g" diff.html.in > apidiff/net47_net4x.html
	rm -f temp.patch
