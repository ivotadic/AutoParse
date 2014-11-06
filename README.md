<h1>What & Why?</h1>
<p>AutoParse is a simple wrapper to .NET's <i>TryParse</i> methods that are found on many of the standard types.  It takes away the need to use the <i>out</i> parameters and also provides an overload for custom parsing.</p>
<br/>
<p>Typical tryparse usage looks like this:</p>
<pre>
	<code>
		int number;
		if(int.TryParse("123456", out number))
			// we parsed
		else
			// we didn't
	</code>
</pre>
<br/>
<p>In cases where you don't really have any conditional logic, but don't want to fail if the value cannot be parsed, AutoParse simplifies it:</p>
<pre>
	<code>
		var number = "123456".TryParse&lt;int&gt;();
	</code>
</pre>
<br/>
<p>In cases where you want to specify a default value when parsing fails then you can use:</p>
<pre>
	<code>
		// "1.5".TryParse&lt;int&gt;() will return 0 by default.
		// By providing a default parameter you can control the return value when parsing fails
		var number = "1.5".TryParse&lt;int&gt;(10);
		
		// OR the simplified version
		var number = "1.5".TryParse(10);
	</code>
</pre>