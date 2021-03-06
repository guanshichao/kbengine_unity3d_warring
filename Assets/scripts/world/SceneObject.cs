using UnityEngine;
using KBEngine;
using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;

public class SceneObject : AssetAsyncLoadObjectCB
{
	public bool visble = true;
	public bool isWatcherLoad = false;
	
	private Vector3 _position = Vector3.zero;
	private Vector3 _eulerAngles = Vector3.zero;
	private Vector3 _scale = Vector3.zero;
	private float _speed = 0f;
	
	public SceneObject()
	{
	}

    public string name {  
        get;  
        set;  
    } 
	
    public string idkey {  
        get;  
        set;  
    }  
	
    public Asset asset {  
        get;  
        set;  
    }  
  
    public Vector3 position {  
		get
		{
			return _position;
		}

		set
		{
			_position = value;
			
			if(gameObject != null)
				gameObject.transform.position = _position;
		}    
    }  
  
    public Vector3 eulerAngles {  
		get
		{
			return _eulerAngles;
		}

		set
		{
			_eulerAngles = value;
			
			if(gameObject != null)
			{
				gameObject.transform.eulerAngles = _eulerAngles;
			}
		}    
    }  

    public Quaternion rotation {  
		get
		{
			return Quaternion.Euler(_eulerAngles);
		}

		set
		{
			eulerAngles = value.eulerAngles;
		}    
    }  
    
    public Vector3 scale {  
		get
		{
			return _scale;
		}

		set
		{
			_scale = value;
			
			if(gameObject != null)
				gameObject.transform.localScale = _scale;
		}    
    } 

    public float speed {  
		get
		{
			return _speed;
		}

		set
		{
			_speed = value;
		}    
    } 
    
    public UnityEngine.GameObject gameObject {  
        get;  
        set;  
    }
	
	public virtual void Instantiate()
	{
		if(gameObject != null)
			return;
		
		asset.Instantiate(this, name, _position, _eulerAngles, _scale);
	}
	
	public override void onAssetAsyncLoadObjectCB(string name, UnityEngine.Object obj, Asset asset)
	{
		gameObject = obj as UnityEngine.GameObject;
		
		if(gameObject != null)
		{
			Common.DEBUG_MSG("SceneObject::onAssetAsyncLoadObjectCB: name(" + name + 
				") is successfully! position(" + _position.x + "," + _position.y + "," + _position.z + "), scale(" + _scale.x + "," + _scale.y + "," + _scale.z + ")");
		}
	}
	
	public virtual void onLoadProgress(float value)
	{
		
	}
}

