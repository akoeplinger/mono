thisdir = tools/mconfig
SUBDIRS = 
include ../../build/rules.make

LOCAL_MCS_FLAGS =
LIB_REFS = System.Xml System
PROGRAM = mconfig.exe

install-local: install-local-data

uninstall-local: uninstall-local-data

install-local-data:
	$(MKINSTALLDIRS) $(DESTDIR)$(sysconfdir)/mono/mconfig/
	$(INSTALL_DATA) data/config.xml $(DESTDIR)$(sysconfdir)/mono/mconfig

uninstall-local-data:
	rm -f $(DESTDIR)$(sysconfdir)/mono/mconfig/config.xml

EXTRA_DISTFILES = TODO data/config.xml Mono.MonoConfig/consts.cs.in

include ../../build/executable.make
