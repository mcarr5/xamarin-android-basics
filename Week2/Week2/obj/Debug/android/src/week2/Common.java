package week2;


public class Common
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Week2.Common, Week2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Common.class, __md_methods);
	}


	public Common () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Common.class)
			mono.android.TypeManager.Activate ("Week2.Common, Week2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
