Welcome to the FreeBSD archive!
-------------------------------

Here you will find the official releases of FreeBSD, along with the ports
collection and other FreeBSD-related material.  We encourage you to visit
the FreeBSD home page at:

   http://www.FreeBSD.org/


Contents of this directory:
---------------------------
releases/ISO-IMAGES/
    The official FreeBSD release ISO images for CD-ROM and DVD; useful for
    installing new machines (virtual or otherwise).

releases/${MACHINE}/${MACHINE_ARCH}/*-RELEASE/
    The official FreeBSD releases as individual tarballs to download; useful
    for jail hosting, updating machines in situ, etc.  Make sure to look in
    the ${MACHINE_ARCH} sub-directory for the most recent releases (e.g.,
    releases/amd64/amd64); this is a change from the earlier ${ARCH} naming
    scheme (e.g., releases/amd64).

snapshots/${MACHINE}/${MACHINE_ARCH}/*-{STABLE,CURRENT}/
    Intermittently updated snapshots of -CURRENT and selected -STABLE
    branches.  A good way to seed a development machine or test in-progress
    FreeBSD features.

doc/
    Documentation for FreeBSD including the FAQ and the FreeBSD
    handbook.  Both these documents are available in hypertext
    form from http://www.FreeBSD.org/

ports/ports/
    A tarball of the FreeBSD ports collection.  It contains the
    makefiles, patches and configuration scripts necessary to make
    the applications available from the distfiles cache
    (http://distcache.FreeBSD.org/ports-distfiles/) compile and run
    on FreeBSD.  If your FreeBSD machine is connected to the
    Internet, you need not download the application source code
    from distfiles/ because the makefile will automatically fetch
    it for you.  A better way to update your ports collection is to use
    the portsnap tool: see 

      http://www.freebsd.org/doc/en_US.ISO8859-1/books/handbook/ports.html

    for more information.

ports/${ARCH}/
    The FreeBSD package collection for supported architectures of the
    FreeBSD 8.4-RELEASE.  These are pre-compiled applications ready
    to install with the pkg_add command.  Note that these packages are
    "frozen" to the state of the package collection at the time
    of release.

    For newer packages and branches, pkg(8) must be used instead and
    are not available from this mirror.  pkg(8) uses packages from the
    official FreeBSD pkg CDN.  Due to very high requirements of
    bandwidth, storage and administration this CDN is maintained by the
    FreeBSD Cluster Administrators and not available for public
    mirroring.

ports/distfiles/
    Relocated to: http://distcache.FreeBSD.org/ports-distfiles/
ports/local-distfiles/
    Relocated to: http://distcache.FreeBSD.org/local-distfiles/

tools/
    A collection of useful tools for people installing FreeBSD.
    This includes MS-DOS tools such as RAWRITE used for
    making installation disks, FIPS for splitting an MS-DOS
    partition and a couple boot managers to allow easy booting on
    computers with more than one operating system installed.

    NOTE: most of these tools are very old, possibly obsolete, and
    will be of limited utility to most users.


Mirror Sites:
-------------
The mirroring of FreeBSD distributions from this location is handled by
mapping each FreeBSD mirror into a common "namespace" which can be said
to follow this rule:

	ftp://ftp[n][.domain].FreeBSD.org/pub/FreeBSD

Where "n" is an optional, logical site number (when you have more than one
FTP server for a domain) and ".domain" is an optional domain, specifying
which particular region of the world you're interested in.  Examples:

	ftp://ftp3.FreeBSD.org/pub/FreeBSD	[3rd logical ftp mirror]
	ftp://ftp.fr.FreeBSD.org/pub/FreeBSD	[primary French mirror]
	ftp://ftp4.de.FreeBSD.org/pub/FreeBSD	[4th logical German mirror]

Logical site assignments are dynamic, with the "fastest, best connected"
mirrors having the lowest logical numbers.  The DNS administrators are
expected to keep this true as mirror sites are created or retired.


New Mirrors:
------------
NOTE: Currently The FreeBSD Project is not looking for additional
mirrors.

You can find information on setting up a FreeBSD mirror here:

    http://www.freebsd.org/doc/en/articles/hubs/
