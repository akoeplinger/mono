thisdir = tools/corcompare
SUBDIRS =
include ../../build/rules.make

LIB_REFS = System.Xml System.Core System
LOCAL_MCS_FLAGS =

ifeq ($(PROFILE),monodroid_tools)
LIB_REFS += Xamarin.Android.Cecil
else
LIB_REFS += Mono.Cecil
endif

PROGRAM = mono-api-info.exe

include ../../build/executable.make
