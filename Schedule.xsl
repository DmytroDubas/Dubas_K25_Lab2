<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>University Schedule</title>
				<style>
					table { border-collapse: collapse; width: 100%; }
					th, td { border: 1px solid black; padding: 8px; text-align: left; }
					th { background-color: #f2f2f2; }
				</style>
			</head>
			<body>
				<h2>Class Schedule</h2>
				<table>
					<tr>
						<th>Day</th>
						<th>Time</th>
						<th>Subject</th>
						<th>Teacher</th>
						<th>Group</th>
						<th>Auditorium</th>
					</tr>
					<xsl:for-each select="Schedule/Lesson">
						<tr>
							<td>
								<xsl:value-of select="@Day"/>
							</td>
							<td>
								<xsl:value-of select="@Time"/>
							</td>
							<td>
								<xsl:value-of select="@Subject"/>
							</td>
							<td>
								<xsl:value-of select="@Teacher"/>
							</td>
							<td>
								<xsl:value-of select="@Group"/>
							</td>
							<td>
								<xsl:value-of select="@Auditorium"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>