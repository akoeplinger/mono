thisdir = class/Mono.Cecil.Mdb
include ../../build/rules.make

ifeq ($(PROFILE),monodroid_tools)
LIBRARY = Xamarin.Android.Cecil.Mdb.dll
else
LIBRARY = Mono.Cecil.Mdb.dll
endif
KEYFILE = ../mono.snk
LIBRARY_PACKAGE = none

API_BUILD := $(filter build, $(PROFILE))

ifdef API_BUILD
TARGET_NET_REFERENCE = $(BOOTSTRAP_BIN_PROFILE)
LIBRARY_USE_INTERMEDIATE_FILE = 1
endif

LIB_REFS = System

ifeq ($(PROFILE),monodroid_tools)
LIB_REFS += Xamarin.Android.Cecil
Xamarin.Android.Cecil:
	$(MAKE) -C ../Mono.Cecil PROFILE=monodroid_tools
else
LIB_REFS += Mono.Cecil
endif

LIB_MCS_FLAGS = -d:CECIL

NO_TEST = yes
NO_INSTALL = yes

include ../../build/library.make
