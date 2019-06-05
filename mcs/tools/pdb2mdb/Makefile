thisdir = tools/pdb2mdb
SUBDIRS =
include ../../build/rules.make

PROGRAM = pdb2mdb.exe

LOCAL_MCS_FLAGS =
LIB_REFS = Mono.CompilerServices.SymbolWriter System.Core

ifeq ($(PROFILE),monodroid_tools)
LIB_REFS += Xamarin.Android.Cecil
else
LIB_REFS += Mono.Cecil
endif

EXTRA_DISTFILES = LICENSE

include ../../build/executable.make
