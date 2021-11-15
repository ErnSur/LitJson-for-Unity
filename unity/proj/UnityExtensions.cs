using UnityEngine;
using System;

namespace LitJson
{
    public static class UnityExtensions
    {
        public static void Register()
        {
            // -- Type
            JsonMapper.RegisterExporter<Type>((v, w) => { w.Write(v.FullName); });
            JsonMapper.RegisterImporter<string, Type>(Type.GetType);

            JsonMapper.RegisterExporter<Vector2>(WriteVector2);
            JsonMapper.RegisterExporter<Vector3>(WriteVector3);
            JsonMapper.RegisterExporter<Vector4>(WriteVector4);
            JsonMapper.RegisterExporter<Quaternion>(WriteQuaternion);
            JsonMapper.RegisterExporter<Color>(WriteColor);
            JsonMapper.RegisterExporter<Color32>(WriteColor32);
            JsonMapper.RegisterExporter<Bounds>(WriteBounds);
            JsonMapper.RegisterExporter<Rect>(WriteRect);
            JsonMapper.RegisterExporter<RectOffset>(WriteRectOffset);
        }

        private static void WriteRectOffset(RectOffset v, JsonWriter w)
        {
            w.WriteObjectStart();
            w.WriteProperty("top", v.top);
            w.WriteProperty("left", v.left);
            w.WriteProperty("bottom", v.bottom);
            w.WriteProperty("right", v.right);
            w.WriteObjectEnd();
        }

        private static void WriteRect(Rect v, JsonWriter w)
        {
            w.WriteObjectStart();
            w.WriteProperty("x", v.x);
            w.WriteProperty("y", v.y);
            w.WriteProperty("width", v.width);
            w.WriteProperty("height", v.height);
            w.WriteObjectEnd();
        }

        private static void WriteBounds(Bounds v, JsonWriter w)
        {
            w.WriteObjectStart();

            w.WritePropertyName("center");
            WriteVector3(v.center, w);

            w.WritePropertyName("size");
            WriteVector3(v.size, w);

            w.WriteObjectEnd();
        }

        private static void WriteColor32(Color32 v, JsonWriter w)
        {
            w.WriteObjectStart();
            w.WriteProperty("r", v.r);
            w.WriteProperty("g", v.g);
            w.WriteProperty("b", v.b);
            w.WriteProperty("a", v.a);
            w.WriteObjectEnd();
        }

        private static void WriteColor(Color v, JsonWriter w)
        {
            w.WriteObjectStart();
            w.WriteProperty("r", v.r);
            w.WriteProperty("g", v.g);
            w.WriteProperty("b", v.b);
            w.WriteProperty("a", v.a);
            w.WriteObjectEnd();
        }

        private static void WriteQuaternion(Quaternion v, JsonWriter w)
        {
            w.WriteObjectStart();
            w.WriteProperty("x", v.x);
            w.WriteProperty("y", v.y);
            w.WriteProperty("z", v.z);
            w.WriteProperty("w", v.w);
            w.WriteObjectEnd();
        }

        private static void WriteVector4(Vector4 v, JsonWriter w)
        {
            w.WriteObjectStart();
            w.WriteProperty("x", v.x);
            w.WriteProperty("y", v.y);
            w.WriteProperty("z", v.z);
            w.WriteProperty("w", v.w);
            w.WriteObjectEnd();
        }

        private static void WriteVector3(Vector3 v, JsonWriter w)
        {
            w.WriteObjectStart();
            w.WriteProperty("x", v.x);
            w.WriteProperty("y", v.y);
            w.WriteProperty("z", v.z);
            w.WriteObjectEnd();
        }

        private static void WriteVector2(Vector2 v, JsonWriter w)
        {
            w.WriteObjectStart();
            w.WriteProperty("x", v.x);
            w.WriteProperty("y", v.y);
            w.WriteObjectEnd();
        }
    }
}