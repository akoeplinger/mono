thisdir = tools/linker-analyzer
SUBDIRS =
include ../../build/rules.make

PROGRAM = illinkanalyzer.exe

LIB_REFS = System System.Xml System.Core
LOCAL_MCS_FLAGS =

ifeq ($(PROFILE),monodroid_tools)
LIB_REFS += Xamarin.Android.Cecil
else
LIB_REFS += Mono.Cecil
endif

include ../../build/executable.make
