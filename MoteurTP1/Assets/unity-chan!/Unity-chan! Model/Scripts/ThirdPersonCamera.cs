//
// Unityちゃん用の三人称カメラ
// 
// 2013/06/07 N.Kobyasahi
//
using UnityEngine;
using System.Collections;

namespace UnityChan
{
	public class ThirdPersonCamera : MonoBehaviour
	{
		public float smooth = 3f;       // カメラモーションのスムーズ化用変数
        public Shader shader;
        [Range(0, 1)] public float verts_force = 0.0f;
        [Range(-3, 20)] public float contrast = 0.0f;
        [Range(-200, 200)] public float brightness = 0.0f;
        [Range(1, 2)] public float ScansColor = 1.0f; 
        //[Range(0, 1)] public float verts_force_2 = 0.0f;
        private Material _material;
        Transform standardPos;			// the usual position for the camera, specified by a transform in the game
		Transform frontPos;			// Front Camera locater
		Transform jumpPos;			// Jump Camera locater
	
		// スムーズに繋がない時（クイック切り替え）用のブーリアンフラグ
		bool bQuickSwitch = false;  //Change Camera Position Quickly

        protected Material material
        {
            get
            {
                if (_material == null)
                {
                    _material = new Material(shader);
                    _material.hideFlags = HideFlags.HideAndDontSave;
                }
                return _material;
            }
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (shader == null) return;
            Material mat = material;
            mat.SetFloat("_VertsColor", 1 - verts_force);
            mat.SetFloat("_Contrast", contrast);
            mat.SetFloat("_Br", brightness);
            mat.SetFloat("_ScansColor", ScansColor);
            //mat.SetFloat("_VertsColor2", 1 - verts_force_2);
            Graphics.Blit(source, destination, mat);
        }

        void OnDisable()
        {
            if (_material)
            {
                DestroyImmediate(_material);
            }
        }

        void Start ()
		{
			// 各参照の初期化
			standardPos = GameObject.Find ("CamPos").transform;
		
			if (GameObject.Find ("FrontPos"))
				frontPos = GameObject.Find ("FrontPos").transform;

			if (GameObject.Find ("JumpPos"))
				jumpPos = GameObject.Find ("JumpPos").transform;

			//カメラをスタートする
			transform.position = standardPos.position;	
			transform.forward = standardPos.forward;	
		}
	
		void FixedUpdate ()	// このカメラ切り替えはFixedUpdate()内でないと正常に動かない
		{
		
			if (Input.GetButton ("Fire1")) {	// left Ctlr	
				// Change Front Camera
				setCameraPositionFrontView ();
			} else if (Input.GetButton ("Fire2")) {	//Alt	
				// Change Jump Camera
				setCameraPositionJumpView ();
			} else {	
				// return the camera to standard position and direction
				setCameraPositionNormalView ();
			}
		}

		void setCameraPositionNormalView ()
		{
			if (bQuickSwitch == false) {
				// the camera to standard position and direction
				transform.position = Vector3.Lerp (transform.position, standardPos.position, Time.fixedDeltaTime * smooth);	
				transform.forward = Vector3.Lerp (transform.forward, standardPos.forward, Time.fixedDeltaTime * smooth);
			} else {
				// the camera to standard position and direction / Quick Change
				transform.position = standardPos.position;	
				transform.forward = standardPos.forward;
				bQuickSwitch = false;
			}
		}
	
		void setCameraPositionFrontView ()
		{
			// Change Front Camera
			bQuickSwitch = true;
			transform.position = frontPos.position;	
			transform.forward = frontPos.forward;
		}

		void setCameraPositionJumpView ()
		{
			// Change Jump Camera
			bQuickSwitch = false;
			transform.position = Vector3.Lerp (transform.position, jumpPos.position, Time.fixedDeltaTime * smooth);	
			transform.forward = Vector3.Lerp (transform.forward, jumpPos.forward, Time.fixedDeltaTime * smooth);		
		}
	}
}