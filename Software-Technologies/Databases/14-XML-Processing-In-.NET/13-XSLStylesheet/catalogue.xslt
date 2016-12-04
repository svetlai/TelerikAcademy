<?xml version="1.0" encoding="utf-8"?>
<!--13. Create an XSL stylesheet, which transforms the file 
catalog.xml into HTML document, formatted for 
viewing in a standard Web-browser.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <html>
      <body>
            <xsl:for-each select="/catalogue/album">
              <ul>
                Album:<br></br>
                <li>
                Name: <xsl:value-of select="name"/>
              </li>
              <li>
                Artist: <xsl:value-of select="artist"/>
              </li>
              <li>
                Producer: <xsl:value-of select="producer"/>
              </li>
              <li>
                Price: <xsl:value-of select="price"/>
              </li>
              <li>
                  <xsl:for-each select="current()/songs/song">
                    <ul> Song:
                    <li>
                      Title: <xsl:value-of select="title"/>
                    </li>
                    <li>
                      Duration: <xsl:value-of select="duration"/>
                    </li>
                    </ul>
                  <br></br>
                  </xsl:for-each>
              </li>
              </ul>
            </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
