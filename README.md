# QP.EntityFramework
T4 Templates that generates EF Core classes to implement Data Access Layer in custom applications working with QP

To make it working it is required to fix VS config file:

with 

			<dependentAssembly>
				<assemblyIdentity name="System.Runtime" publicKeyToken="b03f5f7f11d50a3a" culture="neutral"/>
				<bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="4.0.0.0"/>
			</dependentAssembly>
			<dependentAssembly>
				<assemblyIdentity name="System.Xml.XDocument" publicKeyToken="b03f5f7f11d50a3a" culture="neutral"/>
				<bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="4.0.0.0"/>
			</dependentAssembly>
			<dependentAssembly>
				<assemblyIdentity name="System.Linq" publicKeyToken="b03f5f7f11d50a3a" culture="neutral"/>
				<bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="4.0.0.0"/>
			</dependentAssembly>
			<dependentAssembly>
				<assemblyIdentity name="System.ComponentModel.TypeConverter" publicKeyToken="b03f5f7f11d50a3a" culture="neutral"/>
				<bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="4.0.0.0"/>
			</dependentAssembly>
			<dependentAssembly>
				<assemblyIdentity name="System.Runtime.Extensions" publicKeyToken="b03f5f7f11d50a3a" culture="neutral"/>
				<bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="4.0.0.0"/>
			</dependentAssembly>
			<dependentAssembly>
				<assemblyIdentity name="System.Collections" publicKeyToken="b03f5f7f11d50a3a" culture="neutral"/>
				<bindingRedirect oldVersion="0.0.0.0-5.0.0.0" newVersion="4.0.0.0"/>
			</dependentAssembly>


according VS bug:

https://stackoverflow.com/questions/51550265/t4-template-could-not-load-file-or-assembly-system-runtime-version-4-2-0-0



