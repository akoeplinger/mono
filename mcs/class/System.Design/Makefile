thisdir = class/System.Design
SUBDIRS = 
include ../../build/rules.make

LIBRARY = System.Design.dll


LIB_REFS = System System.Xml System.Web System.Windows.Forms System.Drawing Accessibility System.Data System.Configuration
LIB_MCS_FLAGS = -r:$(corlib)

plainweb_dir = $(the_libdir_base)plainweb
LOCAL_MCS_FLAGS = -lib:$(plainweb_dir)

plainweb = $(plainweb_dir)/System.Web.dll
system_design_deps = $(plainweb)

TEST_MCS_FLAGS = /r:System.dll -r:System.Drawing.dll -r:System.Windows.Forms

include ../../build/library.make

$(the_libdir_base)$(LIBRARY): $(system_design_deps)

$(plainweb):
	(cd ../System.Web; $(MAKE) $@)

.NOTPARALLEL: $(plainweb)
