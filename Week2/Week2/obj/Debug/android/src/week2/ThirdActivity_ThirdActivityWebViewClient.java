package week2;


public class ThirdActivity_ThirdActivityWebViewClient
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_shouldOverrideUrlLoading:(Landroid/webkit/WebView;Ljava/lang/String;)Z:GetShouldOverrideUrlLoading_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"";
		mono.android.Runtime.register ("Week2.ThirdActivity/ThirdActivityWebViewClient, Week2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ThirdActivity_ThirdActivityWebViewClient.class, __md_methods);
	}


	public ThirdActivity_ThirdActivityWebViewClient () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ThirdActivity_ThirdActivityWebViewClient.class)
			mono.android.TypeManager.Activate ("Week2.ThirdActivity/ThirdActivityWebViewClient, Week2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean shouldOverrideUrlLoading (android.webkit.WebView p0, java.lang.String p1)
	{
		return n_shouldOverrideUrlLoading (p0, p1);
	}

	private native boolean n_shouldOverrideUrlLoading (android.webkit.WebView p0, java.lang.String p1);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
