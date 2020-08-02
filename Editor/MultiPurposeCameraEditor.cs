﻿using LegendaryTools.CameraTools;
using UnityEditor;

namespace LegendaryTools.Editor.Inspector
{
    [CustomEditor(typeof(MultiPurposeCamera))]
    public class MultiPurposeCameraEditor : UnityEditor.Editor
    {
        private SerializedProperty CanFollow;

        private SerializedProperty CanFreeLook;

        private SerializedProperty CanOrbit;

        private SerializedProperty CanZoom;
        private SerializedProperty FollowDamping;
        private SerializedProperty FollowHeight;
        private SerializedProperty FollowHeuristic;
        private SerializedProperty FollowLookDamping;
        private SerializedProperty FollowLookTargetHeuristic;
        private SerializedProperty FollowRotation;

        private SerializedProperty followSmoothSpeed;
        private SerializedProperty followTargetPosition;
        private SerializedProperty followTargetRotation;
        private SerializedProperty FollowUseCameraRotation;
        private SerializedProperty FreeLookAxis;
        private SerializedProperty FreeLookForceTargetRotation;
        private SerializedProperty FreeLookForceTargetRotationDamping;
        private SerializedProperty FreeLookForceTargetRotationHeuristic;
        private SerializedProperty FreeLookMax;
        private SerializedProperty FreeLookMin;
        private SerializedProperty freeLookRotation;
        private SerializedProperty FreeLookSensitivity;

        public MultiPurposeCamera Instance;
        private bool isInit;
        private SerializedProperty OrbitCurrentRotation;
        private SerializedProperty OrbitSensivity;
        private SerializedProperty OrbitYLimit;
        private SerializedProperty PointerDelta;

        private SerializedProperty Script;
        private SerializedProperty ScrollDelta;
        private SerializedProperty Target;

        private SerializedProperty UseDefaultInput;
        private SerializedProperty ZoomDistance;
        private SerializedProperty ZoomMinMax;
        private SerializedProperty ZoomSensivity;

        private void Init()
        {
            Script = serializedObject.FindProperty("m_Script");
            Target = serializedObject.FindProperty("Target");

            CanFreeLook = serializedObject.FindProperty("CanFreeLook");
            FreeLookForceTargetRotation = serializedObject.FindProperty("FreeLookForceTargetRotation");
            FreeLookForceTargetRotationHeuristic =
                serializedObject.FindProperty("FreeLookForceTargetRotationHeuristic");
            FreeLookForceTargetRotationDamping = serializedObject.FindProperty("FreeLookForceTargetRotationDamping");
            FreeLookAxis = serializedObject.FindProperty("FreeLookAxis");
            FreeLookSensitivity = serializedObject.FindProperty("FreeLookSensitivity");
            FreeLookMin = serializedObject.FindProperty("FreeLookMin");
            FreeLookMax = serializedObject.FindProperty("FreeLookMax");
            freeLookRotation = serializedObject.FindProperty("freeLookRotation");

            CanOrbit = serializedObject.FindProperty("CanOrbit");
            OrbitSensivity = serializedObject.FindProperty("OrbitSensivity");
            OrbitYLimit = serializedObject.FindProperty("OrbitYLimit");
            OrbitCurrentRotation = serializedObject.FindProperty("OrbitCurrentRotation");

            CanFollow = serializedObject.FindProperty("CanFollow");
            FollowRotation = serializedObject.FindProperty("FollowRotation");
            FollowLookTargetHeuristic = serializedObject.FindProperty("FollowLookTargetHeuristic");
            FollowLookDamping = serializedObject.FindProperty("FollowLookDamping");
            FollowUseCameraRotation = serializedObject.FindProperty("FollowUseCameraRotation");
            FollowHeuristic = serializedObject.FindProperty("FollowHeuristic");
            FollowDamping = serializedObject.FindProperty("FollowDamping");
            FollowHeight = serializedObject.FindProperty("FollowHeight");

            followSmoothSpeed = serializedObject.FindProperty("followSmoothSpeed");
            followTargetPosition = serializedObject.FindProperty("followTargetPosition");
            followTargetRotation = serializedObject.FindProperty("followTargetRotation");

            CanZoom = serializedObject.FindProperty("CanZoom");
            ZoomSensivity = serializedObject.FindProperty("ZoomSensivity");
            ZoomMinMax = serializedObject.FindProperty("ZoomMinMax");
            ZoomDistance = serializedObject.FindProperty("ZoomDistance");

            UseDefaultInput = serializedObject.FindProperty("UseDefaultInput");
            PointerDelta = serializedObject.FindProperty("PointerDelta");
            ScrollDelta = serializedObject.FindProperty("ScrollDelta");

            Instance = serializedObject.targetObject as MultiPurposeCamera;
        }

        public override void OnInspectorGUI()
        {
            Init();

            EditorGUILayout.PropertyField(Script);

            if (Instance.Target == null)
            {
                EditorGUILayout.HelpBox("Target is required", MessageType.Error);
            }

            EditorGUILayout.PropertyField(Target);

            EditorGUILayout.PropertyField(CanFreeLook);

            if (Instance.CanFreeLook)
            {
                EditorGUILayout.PropertyField(FreeLookForceTargetRotation);

                if (Instance.FreeLookForceTargetRotation)
                {
                    EditorGUILayout.PropertyField(FreeLookForceTargetRotationHeuristic);
                    EditorGUILayout.PropertyField(FreeLookForceTargetRotationDamping);
                }

                EditorGUILayout.PropertyField(FreeLookAxis);
                EditorGUILayout.PropertyField(FreeLookSensitivity);
                EditorGUILayout.PropertyField(FreeLookMin);
                EditorGUILayout.PropertyField(FreeLookMax);

                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.PropertyField(freeLookRotation);
                EditorGUI.EndDisabledGroup();
            }

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(CanOrbit);

            if (Instance.CanOrbit)
            {
                EditorGUILayout.PropertyField(OrbitSensivity);
                EditorGUILayout.PropertyField(OrbitYLimit);
                EditorGUILayout.PropertyField(OrbitCurrentRotation);
            }

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(CanFollow);

            if (Instance.CanFollow)
            {
                EditorGUILayout.PropertyField(FollowRotation);
                EditorGUILayout.PropertyField(FollowLookTargetHeuristic);
                EditorGUILayout.PropertyField(FollowLookDamping);
                EditorGUILayout.PropertyField(FollowUseCameraRotation);

                if (Instance.FollowUseCameraRotation)
                {
                    EditorGUILayout.PropertyField(FollowHeuristic);
                    EditorGUILayout.PropertyField(FollowDamping);
                    EditorGUILayout.PropertyField(FollowHeight);
                }

                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.PropertyField(followSmoothSpeed);
                EditorGUILayout.PropertyField(followTargetPosition);
                EditorGUILayout.PropertyField(followTargetRotation);
                EditorGUI.EndDisabledGroup();
            }

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(CanZoom);

            if (Instance.CanZoom)
            {
                EditorGUILayout.PropertyField(ZoomSensivity);
                EditorGUILayout.PropertyField(ZoomMinMax);
                EditorGUILayout.PropertyField(ZoomDistance);
            }

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(UseDefaultInput);
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(PointerDelta);
            EditorGUILayout.PropertyField(ScrollDelta);
            EditorGUI.EndDisabledGroup();

            serializedObject.ApplyModifiedProperties();
        }
    }
}