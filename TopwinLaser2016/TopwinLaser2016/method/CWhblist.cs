using System;
using System.Drawing;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
namespace TopwinLaser2016
{
    public struct tagDXFSTRING
    {
        public string strCode;
        public string strValue;

        public tagDXFSTRING(string s1,string s2)
        {
            strCode = s1;
            strValue = s2;
        }
    }
    public class CWhListContainer
    {        
        private LinkedList<object> m_pListContainer = new LinkedList<object>();
        public Rectangle m_rcBound = new Rectangle();

        public void Serialize(ref BinaryFormatter ar)
        {            
            m_pListContainer.Serialize(ar);
            if (ar.IsLoading() != 0)
            {
                ar >> m_rcBound;
            }
            else
            {
                ar << m_rcBound;
            }
        }
        public void UpdateBoundRect()
        {

            m_rcBound.SetRect(0, 0, 0, 0);


            Rectangle rcUnion = new Rectangle();
            CWhVirtual pObj = null;
            __POSITION pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);

                if (pObj.GetIsShow() == 0)
                {
                    continue;
                }
                pObj.UpdateBoundRect();

                if (m_rcBound.IsEmpty)
                {
                    m_rcBound = pObj.m_rcBound;
                }
                else
                {
                    rcUnion.UnionRect(m_rcBound, pObj.m_rcBound);
                    m_rcBound.SetRect(rcUnion.Left, rcUnion.Top, rcUnion.Right, rcUnion.Bottom);
                    m_rcBound.NormalizeRect();
                }
            }
        }
        public Rectangle GetRcBound()
        {
            return m_rcBound;
        }
        public void UpdateListObjParent()
        {
            CWhVirtual pObj = null;
            __POSITION posObj = m_pListContainer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListContainer.GetNext(posObj);
                pObj.m_pParentList = this;
                if (pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObj).m_pListLayer.UpdateListObjParent();
                }
            }
        }
        public void UpdateListObjID(ref int lIDBegin)
        {

            CWhVirtual pObj = null;
            __POSITION posObj = m_pListContainer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListContainer.GetNext(posObj);
                pObj = posObj.
                pObj.m_lID = ++lIDBegin;
                if (pObj.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObj).m_pListLayer.UpdateListObjID(ref lIDBegin);
                }
            }
        }

        public LinkedList<object> GetObjList()
        {
            return m_pListContainer;
        }
        public int GetCount()
        {
            return m_pListContainer.Count;
        }
        public int IsEmpty()
        {
            return m_pListContainer.Count;
        }
        public CWhVirtual GetTail()
        {
            CWhVirtual pObj = null;
            if (IsEmpty() == 0)
            {
                pObj = m_pListContainer.Last;
            }
            return pObj;
        }
        public CWhVirtual GetHead()
        {
            CWhVirtual pObj = null;
            if (IsEmpty() == 0)
            {
                pObj = m_pListContainer.GetHead();
            }
            return pObj;
        }
        public __POSITION GetHeadPosition()
        {
            return m_pListContainer.GetHeadPosition();
        }
        public __POSITION GetTailPosition()
        {
            return m_pListContainer.GetTailPosition();
        }
        public CWhVirtual GetNext(ref __POSITION pos)
        {
            return m_pListContainer.GetNext(pos);
        }
        public CWhVirtual GetPrev(ref __POSITION pos)
        {
            return m_pListContainer.GetPrev(pos);
        }
        public CWhVirtual GetAt(ref __POSITION pos)
        {
            CWhVirtual pObj = null;
            pObj = m_pListContainer.GetAt(pos);
            return pObj;
        }
        public int IsObjInListContainer(CWhVirtual pObj)
        {
            if (FindObject(pObj) != 0)
            {
                return DefineConstantsWhListContainer.TRUE;
            }
            return DefineConstantsWhListContainer.FALSE;
        }
        public int FindObject(CWhVirtual pObj)
        {

            int bRet = DefineConstantsWhListContainer.FALSE;
            __POSITION pos = m_pListContainer.Find(pObj);
            if (pos != null)
            {
                bRet = DefineConstantsWhListContainer.TRUE;
                return bRet;
            }

            CWhVirtual pObjNext = null;
            __POSITION posNext = m_pListContainer.GetHeadPosition();
            while (posNext != null)
            {
                pObjNext = m_pListContainer.GetNext(posNext);

                if (pObjNext.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    if (((CWhLayer)pObjNext).FindObject(pObj))
                    {
                        bRet = DefineConstantsWhListContainer.TRUE;
                        return bRet;
                    }
                }
            }

            return bRet;
        }
        public CWhVirtual FindObjectFromID(int lID)
        {
            CWhVirtual pObjRet = null;
            CWhVirtual pObj = null;
            __POSITION pos = m_pListContainer.GetHeadPosition();
            while (pos != null)
            {

                pObj = m_pListContainer.GetNext(pos);
                if (pObj.m_lID == lID)
                {
                    pObjRet = pObj;
                    return pObjRet;
                }

                if (pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    pObjRet = ((CWhLayer)pObj).FindObjectFromID(lID);
                    if (pObjRet != null)
                    {
                        break;
                    }
                }
            }

            return pObjRet;
        }
        public CWhVirtual FindLayerFromName(string strLayerName)
        {
            CWhVirtual pObjRet = null;
            CWhVirtual pObj = null;
            __POSITION pos = m_pListContainer.GetHeadPosition();
            while (pos != null)
            {

                pObj = m_pListContainer.GetNext(pos);
                if (pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    if (((CWhLayer)pObj).m_strLayerName == strLayerName)
                    {
                        pObjRet = pObj;
                        break;
                    }
                }
            }

            return pObjRet;
        }
        public __POSITION Find(CWhVirtual pObj)
        {
            __POSITION posRet = new __POSITION(null);
            posRet = m_pListContainer.Find(pObj);
            return posRet;
        }
        public void SetAt(__POSITION pos, CWhVirtual pObj)
        {

            pObj.AddRef();

            if (!pObj.m_pParentList)
            {
                pObj.m_pParentList = this;
            }

            m_pListContainer.SetAt(pos, pObj);

            Rectangle rcUnion = new Rectangle();
            if (m_rcBound.IsRectNull())
            {
                m_rcBound = pObj.m_rcBound;
            }
            else
            {
                rcUnion.UnionRect(m_rcBound, pObj.m_rcBound);
                m_rcBound.SetRect(rcUnion.Left, m_rcBound.Top, m_rcBound.Right, m_rcBound.Bottom);
                m_rcBound.NormalizeRect();
            }
        }
        public void InsertAfterObj(CWhVirtual pObj, CWhVirtual pObjAfter)
        {
            __POSITION posAfter = Find(pObj);

            pObjAfter.AddRef();

            if (!pObjAfter.m_pParentList)
            {
                pObjAfter.m_pParentList = this;
            }

            m_pListContainer.InsertAfter(posAfter, pObjAfter);

            Rectangle rcUnion = new Rectangle();
            if (m_rcBound.IsRectNull())
            {
                m_rcBound = pObjAfter.m_rcBound;
            }
            else
            {
                rcUnion.UnionRect(m_rcBound, pObjAfter.m_rcBound);
                m_rcBound.SetRect(rcUnion.Left, rcUnion.Top, rcUnion.Right, rcUnion.Bottom);
                m_rcBound.NormalizeRect();
            }
        }
        public void InsertPreObj(CWhVirtual pObj, CWhVirtual pObjPre)
        {
            __POSITION posPre = Find(pObj);

            pObjPre.AddRef();

            if (!pObjPre.m_pParentList)
            {
                pObjPre.m_pParentList = this;
            }

            m_pListContainer.InsertBefore(posPre, pObjPre);

            Rectangle rcUnion = new Rectangle();
            if (m_rcBound.IsRectNull())
            {
                m_rcBound = pObjPre.m_rcBound;
            }
            else
            {
                rcUnion.UnionRect(m_rcBound, pObjPre.m_rcBound);
                m_rcBound.SetRect(rcUnion.Left, rcUnion.Top, rcUnion.Right, rcUnion.Bottom);
                m_rcBound.NormalizeRect();
            }
        }
        public CWhVirtual GetAfterObj(CWhVirtual pObj)
        {
            CWhVirtual pObjRet = null;
            __POSITION posObj = Find(pObj);
            if (posObj != null)
            {
                pObjRet = GetNext(ref posObj);
                pObjRet = GetNext(ref posObj);
            }
            return pObjRet;
        }
        public CWhVirtual GetPreObj(CWhVirtual pObj)
        {
            CWhVirtual pObjRet = null;
            __POSITION posObj = Find(pObj);
            if (posObj != null)
            {
                pObjRet = GetPrev(ref posObj);
                pObjRet = GetPrev(ref posObj);
            }
            return pObjRet;
        }
        public void MoveObjNext(CWhVirtual pObj)
        {

            CWhVirtual pObjNext = null;
            __POSITION posMove = Find(pObj);
            if (posMove != null)
            {

                pObjNext = GetNext(ref posMove);
                if (posMove != null)
                {
                    m_pListContainer.InsertAfter(posMove, pObjNext);
                    pObjNext = GetPrev(ref posMove);
                    m_pListContainer.RemoveAt(posMove);
                }
                return;
            }

            posMove = GetHeadPosition();
            while (posMove != null)
            {
                pObjNext = GetNext(ref posMove);
                if (pObjNext.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObjNext).MoveObjNext(pObj);
                }
            }
        }
        public void MoveObjPrev(CWhVirtual pObj)
        {

            CWhVirtual pObjPrev = null;
            __POSITION posMove = Find(pObj);
            if (posMove != null)
            {

                pObjPrev = GetPrev(ref posMove);
                if (posMove != null)
                {
                    m_pListContainer.InsertBefore(posMove, pObjPrev);

                    pObjPrev = GetNext(ref posMove);
                    m_pListContainer.RemoveAt(posMove);
                }
                return;
            }

            posMove = GetHeadPosition();
            while (posMove != null)
            {
                pObjPrev = GetNext(ref posMove);
                if (pObjPrev.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObjPrev).MoveObjPrev(pObj);
                }
            }
        }
        public void MoveObjHead(CWhVirtual pObj)
        {

            CWhVirtual pObjHead = null;
            __POSITION posMove = Find(pObj);
            if (posMove != null)
            {
                m_pListContainer.RemoveAt(posMove);
                m_pListContainer.AddHead(pObj);
                return;
            }

            posMove = GetHeadPosition();
            while (posMove != null)
            {
                pObjHead = GetNext(ref posMove);
                if (pObjHead.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObjHead).m_pListLayer.MoveObjHead(pObj);
                }
            }
        }
        public void MoveObjEnd(CWhVirtual pObj)
        {

            CWhVirtual pObjEnd = null;
            __POSITION posMove = Find(pObj);
            if (posMove != null)
            {
                m_pListContainer.RemoveAt(posMove);
                m_pListContainer.AddTail(pObj);
                return;
            }

            posMove = GetHeadPosition();
            while (posMove != null)
            {
                pObjEnd = GetNext(ref posMove);
                if (pObjEnd.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObjEnd).m_pListLayer.MoveObjEnd(pObj);
                }
            }
        }
        public void AntiList()
        {
            LinkedList pAntiList = new LinkedList<string>();
            CWhVirtual pObj = null;
            __POSITION posAnti = GetHeadPosition();
            while (posAnti != null)
            {
                pObj = GetNext(ref posAnti);
                pAntiList.AddHead(pObj);
            }

            m_pListContainer.RemoveAll();

            m_pListContainer = null;

            m_pListContainer = pAntiList;
        }

        public void AddTail(CWhVirtual pObj)
        {
            AddObject(pObj);
        }
        public void AddHead(CWhVirtual pObj)
        {

            pObj.AddRef();

            if (!pObj.m_pParentList)
            {
                pObj.m_pParentList = this;
            }

            m_pListContainer.AddHead(pObj);

            Rectangle rcUnion = new Rectangle();
            if (m_rcBound.IsRectNull())
            {
                m_rcBound = pObj.m_rcBound;
            }
            else
            {
                rcUnion.UnionRect(m_rcBound, pObj.m_rcBound);
                m_rcBound.SetRect(rcUnion.Left, rcUnion.Top, rcUnion.Right, rcUnion.Bottom);
                m_rcBound.NormalizeRect();
            }
        }
        public void AddObject(CWhVirtual pObj)
        {

            pObj.AddRef();

            if (!pObj.m_pParentList)
            {
                pObj.m_pParentList = this;
            }

            m_pListContainer.AddTail(pObj);

            Rectangle rcUnion = new Rectangle();
            if (m_rcBound.IsRectNull())
            {
                m_rcBound = pObj.m_rcBound;
            }
            else
            {
                rcUnion.UnionRect(m_rcBound, pObj.m_rcBound);
                m_rcBound.SetRect(rcUnion.Left, rcUnion.Top, rcUnion.Right, rcUnion.Bottom);
                m_rcBound.NormalizeRect();
            }
        }
        public void AddObjects(CWhListContainer pList)
        {
            CWhVirtual pObj = null;
            __POSITION pos = pList.GetHeadPosition();
            while (pos != null)
            {
                pObj = pList.GetNext(ref pos);
                AddObject(pObj);
            }
        }

        public int RemoveObject(CWhVirtual pObj)
        {
            return RemoveObject(pObj, DefineConstantsWhListContainer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: int RemoveObject(CWhVirtual pObj, int bFlagDepth = DefineConstantsWhListContainer.FALSE)
        public int RemoveObject(CWhVirtual pObj, int bFlagDepth)
        {
            int bRet = DefineConstantsWhListContainer.FALSE;


            __POSITION pos = m_pListContainer.Find(pObj);
            if (pos != null)
            {

                bRet = DefineConstantsWhListContainer.TRUE;
                if (bFlagDepth != 0)
                {
                    if (pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                    {
                        ((CWhLayer)pObj).RemoveAll(bFlagDepth);
                    }
                }

                m_pListContainer.RemoveAt(pos);

                pObj.Release();

                if (pObj.GetRefCount() == 0)
                {
                    pObj.Dispose();
                    pObj = null;
                }

                return bRet;
            }


            CWhVirtual pObjNext = null;
            __POSITION posNext = m_pListContainer.GetHeadPosition();
            while (posNext != null)
            {
                pObjNext = m_pListContainer.GetNext(posNext);

                if (pObjNext.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    if (((CWhLayer)pObjNext).RemoveObject(pObj, bFlagDepth))
                    {
                        bRet = DefineConstantsWhListContainer.TRUE;
                        return bRet;
                    }
                }
            }


            return bRet;
        }
        public void RemoveObjects(CWhListContainer pList)
        {
            RemoveObjects(pList, DefineConstantsWhListContainer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void RemoveObjects(CWhListContainer pList, int bFlagDepth = DefineConstantsWhListContainer.FALSE)
        public void RemoveObjects(CWhListContainer pList, int bFlagDepth)
        {
            CWhVirtual pObj = null;
            __POSITION pos = pList.GetHeadPosition();
            while (pos != null)
            {
                pObj = pList.GetNext(ref pos);
                RemoveObject(pObj, bFlagDepth);
            }

            UpdateBoundRect();
        }
        public void RemoveAll()
        {
            RemoveAll(DefineConstantsWhListContainer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void RemoveAll(int bFlagDepth = DefineConstantsWhListContainer.FALSE)
        public void RemoveAll(int bFlagDepth)
        {
            CWhVirtual pObj = null;
            __POSITION pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                RemoveObject(pObj, bFlagDepth);
            }

            m_rcBound.SetRect(0, 0, 0, 0);
        }
        public void DeleteObject(CWhVirtual pObj)
        {
            DeleteObject(pObj, DefineConstantsWhListContainer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteObject(CWhVirtual pObj, int bFlagDepth = DefineConstantsWhListContainer.FALSE)
        public void DeleteObject(CWhVirtual pObj, int bFlagDepth)
        { //haoge
            pObj.Dispose();
            pObj = null;
        }
        public void DeleteObjects(CWhListContainer pList)
        {
            DeleteObjects(pList, DefineConstantsWhListContainer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteObjects(CWhListContainer pList, int bFlagDepth = DefineConstantsWhListContainer.FALSE)
        public void DeleteObjects(CWhListContainer pList, int bFlagDepth)
        { //haoge
            CWhVirtual pObj = null;
            __POSITION pos = pList.GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                DeleteObject(pObj);
            }
        }
        public void DeleteAll()
        {
            DeleteAll(DefineConstantsWhListContainer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteAll(int bFlagDepth = DefineConstantsWhListContainer.FALSE)
        public void DeleteAll(int bFlagDepth)
        { //haoge
            CWhVirtual pObj = null;
            __POSITION pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                DeleteObject(pObj);
            }
            m_rcBound.SetRect(0, 0, 0, 0);
        }

        public void GroupObj(CWhListContainer pListObj)
        {

            CWhGroup pGroup = new CWhGroup();
            CWhVirtual pObj = null;
            __POSITION posObj = pListObj.GetHeadPosition();
            while (posObj != null)
            {
                pObj = pListObj.GetNext(ref posObj);
                pGroup.AddObject(pObj);

                pObj.m_pParentList = pGroup.m_pListGroup;
            }

            AddObject(pGroup);


        }
        public void ApartAll()
        {
            CWhVirtual pObj = null;
            __POSITION posObj = GetHeadPosition();
            while (posObj != null)
            {
                pObj = GetNext(ref posObj);
                if (pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_GROUP)
                {
                    ((CWhGroup)pObj).Apart();
                    RemoveObject(pObj);
                }
                else if (pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    ((CWhLayer)pObj).m_pListLayer.ApartAll();
                }
            }
        }

        public void FindObjInRect(CWhListContainer pListDestination, Rectangle rcRect)
        {
            CWhVirtual pObjInRect = null;
            int bFlagInRect = DefineConstantsWhListContainer.FALSE;

            __POSITION posInRect = GetHeadPosition();
            while (posInRect != null)
            {
                pObjInRect = GetNext(ref posInRect);
                if (pObjInRect.IsObjInRect(rcRect))
                {

                    if (pObjInRect.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                    {
                        ((CWhLayer)pObjInRect).m_pListLayer.FindObjInRect(pListDestination, rcRect);
                        continue;
                    }

                    pListDestination.AddObject(pObjInRect);
                }
            }
        }
        public int SelectObj(CWhListContainer pListSelect, Point ptClick, int nLimit, ref Graphics pDC)
        {
            int bRet = DefineConstantsWhListContainer.FALSE;
            CWhVirtual pObj = null;
            __POSITION pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                if (pObj.GetIsShow() == 0)
                {
                    continue;
                }
                if (pObj.IsSelected(ptClick, nLimit) != 0)
                {

                    if (pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                    {
                        if (((CWhLayer)pObj).m_pListLayer.SelectObj(pListSelect, ptClick, nLimit, ref pDC))
                        {
                            bRet = DefineConstantsWhListContainer.TRUE;
                            return bRet;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    pObj.SetIsShowHandle(DefineConstantsWhListContainer.TRUE);
                    pObj.SetPenColor(RGB(255, 0, 0));

                    pListSelect.AddObject(pObj);

                    bRet = DefineConstantsWhListContainer.TRUE;
                    return bRet;
                }
            }

            return bRet;
        }
        public int SelectObj(CWhListContainer pListSelect, Rectangle rcClick, int bFlagMode, ref Graphics pDC)
        {
            int bRet = DefineConstantsWhListContainer.FALSE;
            CWhVirtual pObj = null;
            __POSITION pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                if (pObj.IsSelected(rcClick, bFlagMode) != 0)
                {

                    if (pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                    {
                        ((CWhLayer)pObj).m_pListLayer.SelectObj(pListSelect, rcClick, bFlagMode, ref pDC);
                        continue;
                    }

                    pObj.SetIsShowHandle(DefineConstantsWhListContainer.TRUE);
                    pObj.SetPenColor(RGB(255, 0, 0));

                    pListSelect.AddObject(pObj);
                }
            }

            return bRet;
        }
        public int SnapPoint(ref Point ptSnap, Point ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhListContainer.FALSE;

            CWhVirtual pObjSnap = null;
            __POSITION posSnap = GetHeadPosition();
            while (posSnap != null)
            {
                pObjSnap = GetNext(ref posSnap);
                if (pObjSnap.IsPointSnap(ref ptSnap, ptInput, fDiatance) != 0)
                {

                    if (pObjSnap.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                    {
                        if (!((CWhLayer)pObjSnap).m_pListLayer.SnapPoint(ref ptSnap, ptInput, fDiatance))
                        {
                            continue;
                        }
                    }
                    bRet = DefineConstantsWhListContainer.TRUE;
                    return bRet;
                }
            }

            return bRet;
        }
        public int SelectPoint(ref CWhVirtual pSnap, ref Point ptSnap, ref int nSnap, Point ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhListContainer.FALSE;
            CWhVirtual pObjSnap = null;
            __POSITION posSnap = GetHeadPosition();
            while (posSnap != null)
            {
                pObjSnap = GetNext(ref posSnap);
                if (pObjSnap.IsPointSelect(ref ptSnap, ref nSnap, ptInput, fDiatance) != 0)
                {

                    if (pObjSnap.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                    {
                        if (!((CWhLayer)pObjSnap).m_pListLayer.SelectPoint(ref pSnap, ref ptSnap, ref nSnap, ptInput, fDiatance))
                        {
                            continue;
                        }
                    }
                    pSnap = pObjSnap;
                    bRet = DefineConstantsWhListContainer.TRUE;
                    return bRet;
                }
            }

            return bRet;
        }

        public int SelectStartPoint(ref CWhVirtual pObj, ref Point ptRet, Point ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhListContainer.FALSE;
            CWhVirtual pObjStart = null;
            __POSITION posStart = GetHeadPosition();
            while (posStart != null)
            {
                pObjStart = GetNext(ref posStart);
                if (pObjStart.IsStartPointSelect(ref ptRet, ptInput, fDiatance) != 0)
                {

                    if (pObjStart.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                    {
                        if (!((CWhLayer)pObjStart).m_pListLayer.SelectStartPoint(ref pObj, ref ptRet, ptInput, fDiatance))
                        {
                            continue;
                        }
                    }
                    pObj = pObjStart;
                    bRet = DefineConstantsWhListContainer.TRUE;
                    return bRet;
                }
            }

            return bRet;
        }

        public void CopyObjToList(CWhListContainer pList)
        {
            CopyObjToList(pList, DefineConstantsWhListContainer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void CopyObjToList(CWhListContainer pList, int bFlagSingle = DefineConstantsWhListContainer.FALSE)
        public void CopyObjToList(CWhListContainer pList, int bFlagSingle)
        {
            CWhVirtual pObj = null;
            CWhGroup pGroup = null;
            CWhLayer pLayer = null;
            __POSITION pos = GetHeadPosition();
            while (pos != null)
            {
                pObj = GetNext(ref pos);
                if (bFlagSingle != 0 && pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LAYER)
                {
                    CWhLayer pLayer = new CWhLayer();

                    pLayer.m_lID = pObj.m_lID;
                    pLayer.m_bIsShowHandle = pObj.m_bIsShowHandle;
                    pLayer.m_strLayerName = ((CWhLayer)pObj).m_strLayerName;
                    pLayer.m_nMachineCount = pObj.m_nMachineCount;
                    pLayer.m_bMachineStyle = pObj.m_bMachineStyle;
                    pLayer.m_nMachineFrequence = pObj.m_nMachineFrequence;

                    ((CWhLayer)pObj).m_pListLayer.CopyObjToList(pLayer.m_pListLayer, bFlagSingle);
                    pLayer.UpdateBoundRect();
                    pList.AddObject(pLayer);
                    continue;
                }

                pList.AddObject(pObj);
            }
        }

        public void OptimizeObjOrder()
        {

            if (m_pListContainer.IsEmpty())
            {
                return;
            }

            CWhListContainer pListDestinate = new CWhListContainer();
            while (!m_pListContainer.IsEmpty())
            {
                ExtractGroup(this, pListDestinate, 5);
            }

            OptimizeGroup(pListDestinate);

            ArangeGroupOrder(pListDestinate);
            pListDestinate.RemoveAll();
            pListDestinate.Dispose();
            pListDestinate = null;
        }
        public int SearchNearlyNextObj(CWhListContainer pListSource, Point ptInput, double fDistanceGap, ref CWhVirtual pObjRet, int bFlagType)
        {
            int bRet = DefineConstantsWhListContainer.FALSE;
            Point ptstart = new Point(0, 0);
            Point ptEnd = new Point(0, 0);
            CWhVirtual pObjSearch = null;
            __POSITION posObjSearch = pListSource.GetHeadPosition();
            while (posObjSearch != null)
            {
                pObjSearch = pListSource.GetNext(ref posObjSearch);
                ptstart = pObjSearch.GetStartPoint();
                ptEnd = pObjSearch.GetEndPoint();


                if (PointToPointDistance(ptInput, ptstart) < fDistanceGap)
                {
                    if (bFlagType == 0)
                    {
                        pObjSearch.ExchangeStartToEnd();

                    }
                    pObjRet = pObjSearch;
                    bRet = DefineConstantsWhListContainer.TRUE;
                    break;
                }
                else if (PointToPointDistance(ptInput, ptEnd) < fDistanceGap)
                {
                    if (bFlagType != 0)
                    {
                        pObjSearch.ExchangeStartToEnd();
                    }
                    pObjRet = pObjSearch;
                    bRet = DefineConstantsWhListContainer.TRUE;
                    break;
                }
            }

            return bRet;
        }
        public int ExtractGroup(CWhListContainer pListSource, CWhListContainer pListDestinate, double fDistanceGap)
        {
            int bRet = DefineConstantsWhListContainer.FALSE;
            Point ptStartSearch = new Point(0, 0);
            Point ptEndSearch = new Point(0, 0);
            CWhGroup pGroup = new CWhGroup();
            pListDestinate.AddObject(pGroup);
            CWhVirtual pObjOptimize = null;
            CWhVirtual pObjRet = null;

            pObjOptimize = pListSource.GetHead();
            if (pObjOptimize != null)
            {
                pGroup.AddObject(pObjOptimize);
                pListSource.RemoveObject(pObjOptimize);
            }
            if ((pObjOptimize.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_LINE) || (pObjOptimize.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_ARC))
            {
                ptStartSearch = pObjOptimize.GetStartPoint();
                ptEndSearch = pObjOptimize.GetEndPoint();
            }

            while (SearchNearlyNextObj(pListSource, ptEndSearch, fDistanceGap, ref pObjRet, DefineConstantsWhListContainer.TRUE) != 0)
            {
                pGroup.AddObject(pObjRet);
                pListSource.RemoveObject(pObjRet);
                ptEndSearch = pObjRet.GetEndPoint();
            }

            while (SearchNearlyNextObj(pListSource, ptStartSearch, fDistanceGap, ref pObjRet, DefineConstantsWhListContainer.FALSE) != 0)
            {
                pGroup.m_pListGroup.AddHead(pObjRet);
                pListSource.RemoveObject(pObjRet);
                ptStartSearch = pObjRet.GetStartPoint();
            }

            return bRet;
        }
        public int OptimizeGroup(CWhListContainer pList)
        {
            CWhListContainer pListGroup = new CWhListContainer();
            Rectangle rcSearch = new Rectangle(0, 0, 0, 0);
            CWhVirtual pObj = null;

            pList.UpdateBoundRect();

            pObj = pList.GetHead();
            rcSearch = pObj.m_rcBound;
            rcSearch.NormalizeRect();
            if (pObj != null)
            {
                pListGroup.AddObject(pObj);
                pList.RemoveObject(pObj);
            }

            while (pList.IsEmpty() == 0)
            {
                SearchNearlyNextGroup(ref rcSearch, pList, pListGroup);
            }

            pList.AddObjects(pListGroup);
            pListGroup.RemoveAll();
            pListGroup.Dispose();
            pListGroup = null;

            return DefineConstantsWhListContainer.TRUE;
        }
        public void SearchNearlyNextGroup(ref Rectangle rcInPut, CWhListContainer pList, CWhListContainer pListDestinate)
        {
            CWhVirtual pObjRet = null;
            double fDistancePre;
            double fDistanceCur = 0;
            int i = 0;
            Rectangle rcCurrent = new Rectangle(0, 0, 0, 0);
            CWhVirtual pObj = null;
            __POSITION posObj = pList.GetHeadPosition();
            while (posObj != null)
            {
                pObj = pList.GetNext(ref posObj);
                rcCurrent = pObj.m_rcBound;
                fDistanceCur = PointToPointDistance(rcInPut.CenterPoint(), rcCurrent.CenterPoint());
                if (i == 0)
                {
                    fDistancePre = fDistanceCur;
                    pObjRet = pObj;
                    i++;
                    continue;
                }
                if (fDistanceCur < fDistancePre)
                {
                    fDistancePre = fDistanceCur;
                    pObjRet = pObj;
                    continue;
                }
            }

            rcInPut = pObjRet.m_rcBound;
            rcInPut.NormalizeRect();
            pListDestinate.AddObject(pObjRet);
            pList.RemoveObject(pObjRet);
        }
        public void ArangeGroupOrder(CWhListContainer pList)
        {
            CWhVirtual pObj = null;
            __POSITION posObj = pList.GetHeadPosition();
            while (posObj != null)
            {
                pObj = pList.GetNext(ref posObj);
                if (pObj.m_nObjType == DefineConstantsWhListContainer.WH_TYPE_GROUP)
                {
                    AddObjects(((CWhGroup)pObj).m_pListGroup);
                }
            }
        }
    }
    public class CWhCommon : LinkedList<object>
    {
        public int m_nRefCount;

        public void AddRef()
        {
            m_nRefCount++;
        }
        public int GetRefCount()
        {
            return m_nRefCount;
        }
        public void Release()
        {
            m_nRefCount--;
        }
    }
    public class CWhVirtual : CWhCommon
    {
        public static int s_lID;
        public int m_lID;
        public int m_nObjType;
        public Rectangle m_rcBound = new Rectangle();
        public CWhListContainer m_pParentList;

        public int m_nMachineCount; //加工次数
        public int m_bMachineStyle; //加工方式
        public int m_nMachineFrequence; //加工频率
        public int m_bIsShow;
        public int m_bIsShowHandle;
        public int m_bIsSelect;
        public int m_bIsFilled;

        public int m_nPenWidth; //线宽
        public int m_nPenType; //线型
        public uint m_colPenColor; //颜色

        public int m_nBrushType;
        public uint m_colBrush;
        public int m_bFlagIsRegister;

        public Point TransRPtoLP(Point ptInput)
        {
            Point ptRet = new Point();

            ptRet.X = ptInput.X;
            ptRet.Y = -ptInput.Y;
            return ptRet;
        }
        public Point TransLPtoRP(Point ptInput)
        {
            Point ptRet = new Point();
            ptRet.X = ptInput.X;
            ptRet.Y = -ptInput.Y;
            return ptRet;
        }
        public Point TopLeft(Rectangle rcInput)
        {
            Point oldpoint = new Point();
            oldpoint.X = rcInput.Left;
            oldpoint.Y = rcInput.Top;
            return oldpoint;
        }
        public Rectangle TransRPtoLP(Rectangle rcInput)
        {
            Rectangle rcRet = new Rectangle(TransRPtoLP(TopLeft(rcInput)),rcInput.Size);
            return rcRet;
        }
        public Rectangle TransLPtoRP(Rectangle rcInput)
        {
            Rectangle rcRet = new Rectangle(TransRPtoLP(TopLeft(rcInput)), rcInput.Size);
            return rcRet;
        }
        public Point TransDPtoLP(Point ptInput, ref Graphics pDC)
        {
            Point[] ptRet ={ ptInput,ptInput};
            pDC.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Page,System.Drawing.Drawing2D.CoordinateSpace.World,ptRet);
            //pDC.DPtoLP(ptRet);
            return ptRet[0];
        }
        public Rectangle TransDPtoLP(Rectangle rcInput, ref Graphics pDC)
        {
            Rectangle rcRet = rcInput;
            Point[] ptRet = { TopLeft(rcInput), TopLeft(rcInput)};
            ptRet[1].X = rcInput.Right;
            ptRet[1].Y = rcInput.Bottom;
            pDC.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Page, System.Drawing.Drawing2D.CoordinateSpace.World, ptRet);
            rcRet = new Rectangle(ptRet[0].X, ptRet[0].Y,ptRet[1].X, ptRet[1].Y);            
            return rcRet;
        }
        public Point TransDPtoRP(Point ptInput, ref Graphics pDC)
        {
            Point ptRet = new Point();
            Point ptTem = new Point();
            ptTem = TransDPtoLP(ptInput, ref pDC);
            ptRet = TransLPtoRP(ptTem);
            return ptRet;
        }
        public Rectangle TransDPtoRP(Rectangle rcInput, ref Graphics pDC)
        {
            Rectangle rcRet = new Rectangle();
            Rectangle rcTem = new Rectangle();
            rcTem = TransDPtoLP(rcInput, ref pDC);
            rcRet = TransLPtoRP(rcTem);
            return rcRet;
        }
               
        public virtual void Serialize(ref BinaryFormatter ar)
        {                       
            if (ar.IsLoading() != 0)
            {
                ar >> m_nRefCount >> m_lID >> m_nObjType >> m_rcBound >> m_bIsShow >> m_nMachineCount >> m_bIsFilled >> m_bIsShowHandle >> m_nPenWidth >> m_nPenType >> m_colPenColor >> m_nBrushType >> m_colBrush >> m_nMachineFrequence >> m_bFlagIsRegister >> m_bMachineStyle;
            }
            else
            {
                ar << m_nRefCount << m_lID << m_nObjType << m_rcBound << m_bIsShow << m_nMachineCount << m_bIsFilled << m_bIsShowHandle << m_nPenWidth << m_nPenType << m_colPenColor << m_nBrushType << m_colBrush << m_nMachineFrequence << m_bFlagIsRegister << m_bMachineStyle;
            }
        }

        public virtual bool IsValid()
        {
            return true;
        }
        public virtual void Draw(ref Graphics pDC, Rectangle rcClient)
        {

        }
        public virtual void DrawHandle(ref Graphics pDC)
        {

        }
        public virtual void DrawArrow(ref Graphics pDC)
        {

        }
        public virtual void DrawStartPoint(ref Graphics pDC)
        {

        }
        public virtual void DrawNumber(ref Graphics pDC)
        {

        }
        public virtual void UpdateBoundRect()
        {

        }
        public virtual void Move(int nX, int nY)
        {

        }
        public virtual void SetIsShowHandle(int bIsShowHandle)
        {
            m_bIsShowHandle = bIsShowHandle;
        }
        public virtual void ExchangeStartToEnd()
        {

        }
        public virtual Point GetStartPoint()
        {
            Point ptRet = new Point(0, 0);
            return ptRet;
        }
        public virtual Point GetEndPoint()
        {
            Point ptRet = new Point(0, 0);
            return ptRet;
        }
        public virtual bool IsObjValid()
        {
            return true;
        }

        public virtual bool IsSelected(Point ptClick, int nLimit)
        {
            return false;
        }
        public virtual bool IsSelected(Rectangle rcClick, int bFlagMode)
        {
            return false;
        }

        public virtual bool IsObjInRect(Rectangle rcClient)
        {
            return IsObjInRect(rcClient,0);
        }
        public virtual bool IsObjInRect(Rectangle rcClient, int bFlagDepth)
        {
            Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);
            rcInterSectRect = Rectangle.Intersect(m_rcBound, rcClient);
            if (!rcInterSectRect.IsEmpty)
            {
                return true;
            }
            return false;
        }
        public virtual bool IsPointSnap(ref Point ptSnap, Point ptInput, double fDiatance)
        {
            bool bRet = false;
            return bRet;
        }
        public virtual bool IsPointSelect(ref Point ptSnap, ref int nSnap, Point ptInput, double fDiatance)
        {
            return false;
        }
        public virtual bool IsStartPointSelect(ref Point ptRet, Point ptInput, double fDiatance)
        {
            return false;
        }

        public virtual void SetObjDefaultProperty()
        {

        }
        public virtual void SetPenColor(uint colRef)
        {
            m_colPenColor = colRef;
        }
        public virtual void SetBrushColor(uint colRef)
        {
            m_colBrush = colRef;
        }

        public void SetObjType(int nObjType)
        {
            m_nObjType = nObjType;
        }
        public int GetObjType()
        {
            return m_nObjType;
        }
        public void SetIsShow(int bIsShow)
        {
            m_bIsShow = bIsShow;
        }
        public int GetIsShow()
        {
            return m_bIsShow;
        }
        public virtual void SetMachineCount(int nMachineCount)
        {
            m_nMachineCount = nMachineCount;
        }
        public int GetMachineCount()
        {
            return m_nMachineCount;
        }
        public virtual void SetMachineFrequence(int nMachineFrequence)
        {
            m_nMachineFrequence = nMachineFrequence;
        }
        public int GetMachineFrequence()
        {
            return m_nMachineFrequence;
        }
        public void SetPenWidth(int nPenWidth)
        {
            m_nPenWidth = nPenWidth;
        }
        public int GetPenWidth()
        {
            return m_nPenWidth;
        }
        public void SetPenType(int nPenType)
        {
            m_nPenType = nPenType;
        }
        public int GetPenType()
        {
            return m_nPenType;
        }
        public uint GetPenColor()
        {
            return m_colPenColor;
        }
        public void SetIsFilled(int bIsFilled)
        {
            m_bIsFilled = bIsFilled;
        }
        public void SetMachineStyle(int bMachineStyle)
        {
            m_bMachineStyle = bMachineStyle;
        }
        public int GetMachineStyle()
        {
            return m_bMachineStyle;
        }
    }
    public class CWhSysFunction 
    {
        public static int PointToLineDistance(Point pt1, Point pt2, Point pt3)
        {
            if (pt1 == pt2)
            {
                return 0;
            }

            if (pt1 == pt3)
            {
                return 0;
            }


            if (pt1.X == pt2.X)
            {
                return (int)System.Math.Abs(pt1.X - pt3.X);
            }
            else if (pt1.Y == pt2.Y)
            {
                return (int)System.Math.Abs(pt1.Y - pt3.Y);
            }


            double k1 = 0.0;
            double k2 = 0.0;
            double x1 = 0.0;
            double y1 = 0.0;
            double x2 = 0.0;
            double y2 = 0.0;
            double x3 = 0.0;
            double y3 = 0.0;
            double xt = 0.0;
            double yt = 0.0;
            double fDistance = 0.0;
            x1 = pt1.X / DefineConstantsFdxf.TRANSRATIO;
            y1 = pt1.Y / DefineConstantsFdxf.TRANSRATIO;
            x2 = pt2.X / DefineConstantsFdxf.TRANSRATIO;
            y2 = pt2.Y / DefineConstantsFdxf.TRANSRATIO;
            x3 = pt3.X / DefineConstantsFdxf.TRANSRATIO;
            y3 = pt3.Y / DefineConstantsFdxf.TRANSRATIO;

            k1 = (y2 - y1) / (x2 - x1);
            k2 = -1 / k1;
            xt = (y3 - y1 + k1 * x1 - k2 * x3) / (k1 - k2);
            yt = k2 * xt + y3 - k2 * x3;

            fDistance = (x3 - xt) * (x3 - xt) + (y3 - yt) * (y3 - yt);
            fDistance = System.Math.Sqrt(fDistance);
            fDistance *= DefineConstantsFdxf.TRANSRATIO;

            return (int)fDistance;
        }

        public static int PointToPointDistance(Point pt1, Point pt2)
        {
            double x1 = 0.0;
            double y1 = 0.0;
            double x2 = 0.0;
            double y2 = 0.0;
            double fDistance = 0.0;
            x1 = pt1.X / DefineConstantsFdxf.TRANSRATIO;
            y1 = pt1.Y / DefineConstantsFdxf.TRANSRATIO;
            x2 = pt2.X / DefineConstantsFdxf.TRANSRATIO;
            y2 = pt2.Y / DefineConstantsFdxf.TRANSRATIO;

            fDistance = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            fDistance = System.Math.Sqrt(fDistance);
            fDistance *= DefineConstantsFdxf.TRANSRATIO;

            return (int)fDistance;
        }

        public static Point CalCenterPoint(Point pt1, Point pt2, Point pt3)
        {
            Point ptRet = new Point(0, 0);
            double k1 = 0.0;
            double k2 = 0.0;
            double k_1 = 0.0;
            double k_2 = 0.0;
            double x_1 = 0.0;
            double y_1 = 0.0;
            double x_2 = 0.0;
            double y_2 = 0.0;
            double xret = 0.0;
            double yret = 0.0;

            x_1 = (pt1.X + pt2.X) / 2.0;
            y_1 = (pt1.Y + pt2.Y) / 2.0;
            x_2 = (pt2.X + pt3.X) / 2.0;
            y_2 = (pt2.Y + pt3.Y) / 2.0;

            if ((pt1.X == pt2.X) && (pt2.Y == pt3.Y))
            {
                xret = x_2;
                yret = y_1;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if ((pt1.Y == pt2.Y) & (pt2.X == pt3.X))
            {
                xret = x_1;
                yret = y_2;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if (pt1.X == pt2.X)
            {
                yret = y_1;

                k2 = (double)(pt3.Y - pt2.Y) / (double)(pt3.X - pt2.X);
                k_2 = -1 / k2;
                xret = (yret - y_2 + k_2 * x_2) / k_2;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if (pt1.Y == pt2.Y)
            {
                xret = x_1;

                k2 = (double)(pt3.Y - pt2.Y) / (double)(pt3.X - pt2.X);
                k_2 = -1 / k2;
                yret = k_2 * xret + y_2 - k_2 * x_2;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if (pt2.X == pt3.X)
            {
                yret = y_2;

                k1 = (double)(pt2.Y - pt1.Y) / (double)(pt2.X - pt1.X);
                k_1 = -1 / k1;
                xret = (yret - y_1 + k1 * x_1) / k1;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }
            else if (pt2.Y == pt3.Y)
            {
                xret = x_2;

                k1 = (double)(pt2.Y - pt1.Y) / (double)(pt2.X - pt1.X);
                k_1 = -1 / k1;
                yret = k_1 * xret + y_1 - k_1 * x_1;
                ptRet.X = (int)(xret);
                ptRet.Y = (int)(yret);
                return ptRet;
            }


            k1 = (double)(pt2.Y - pt1.Y) / (double)(pt2.X - pt1.X);
            k_1 = -1 / k1;
            k2 = (double)(pt3.Y - pt2.Y) / (double)(pt3.X - pt2.X);
            k_2 = -1 / k2;

            xret = (y_2 - y_1 - k_2 * x_2 + k_1 * x_1) / (k_1 - k_2);
            yret = k_1 * xret + y_1 - k_1 * x_1;

            ptRet.X = (int)(xret);
            ptRet.Y = (int)(yret);
            return ptRet;
        }
    }
    public class DefineConstantsFdxf
    {
        public const int _AFX = 1;
        public const int _MFC_VER = 0x0600;
        public const int STRICT = 1;
        public const int _WIN32_WINDOWS = 0x0500;
        public const int WM_MOUSELAST = 0x0209;
        public const string MSH_MOUSEWHEEL = "MSWHEEL_ROLLMSG";
        public const int WHEEL_DELTA = 120;
        public const string MOUSEZ_CLASSNAME = "MouseZ";
        public const string MOUSEZ_TITLE = "Magellan MSWHEEL";
        public const string MSH_WHEELSUPPORT = "MSH_WHEELSUPPORT_MSG";
        public const string MSH_SCROLL_LINES = "MSH_SCROLL_LINES_MSG";
        public const int SPI_SETWHEELSCROLLLINES = 105;
        public const int _WIN32_IE = 0x0400;
        public const int MAXPROPPAGES = 100;
        public const int PSP_DEFAULT = 0x00000000;
        public const int PSP_DLGINDIRECT = 0x00000001;
        public const int PSP_USEHICON = 0x00000002;
        public const int PSP_USEICONID = 0x00000004;
        public const int PSP_USETITLE = 0x00000008;
        public const int PSP_RTLREADING = 0x00000010;
        public const int PSP_HASHELP = 0x00000020;
        public const int PSP_USEREFPARENT = 0x00000040;
        public const int PSP_USECALLBACK = 0x00000080;
        public const int PSP_PREMATURE = 0x00000400;
        public const int PSP_HIDEHEADER = 0x00000800;
        public const int PSP_USEHEADERTITLE = 0x00001000;
        public const int PSP_USEHEADERSUBTITLE = 0x00002000;
        public const int PSPCB_RELEASE = 1;
        public const int PSPCB_CREATE = 2;
        public const int PSH_DEFAULT = 0x00000000;
        public const int PSH_PROPTITLE = 0x00000001;
        public const int PSH_USEHICON = 0x00000002;
        public const int PSH_USEICONID = 0x00000004;
        public const int PSH_PROPSHEETPAGE = 0x00000008;
        public const int PSH_WIZARDHASFINISH = 0x00000010;
        public const int PSH_WIZARD = 0x00000020;
        public const int PSH_USEPSTARTPAGE = 0x00000040;
        public const int PSH_NOAPPLYNOW = 0x00000080;
        public const int PSH_USECALLBACK = 0x00000100;
        public const int PSH_HASHELP = 0x00000200;
        public const int PSH_MODELESS = 0x00000400;
        public const int PSH_RTLREADING = 0x00000800;
        public const int PSH_WIZARDCONTEXTHELP = 0x00001000;
        public const int PSH_WIZARD97 = 0x00002000;
        public const int PSH_WATERMARK = 0x00008000;
        public const int PSH_USEHBMWATERMARK = 0x00010000;
        public const int PSH_USEHPLWATERMARK = 0x00020000;
        public const int PSH_STRETCHWATERMARK = 0x00040000;
        public const int PSH_HEADER = 0x00080000;
        public const int PSH_USEHBMHEADER = 0x00100000;
        public const int PSH_USEPAGELANG = 0x00200000;
        public const int PSCB_INITIALIZED = 1;
        public const int PSCB_PRECREATE = 2;
        public const int PSNRET_NOERROR = 0;
        public const int PSNRET_INVALID = 1;
        public const int PSNRET_INVALID_NOCHANGEPAGE = 2;
        public const int PSWIZB_BACK = 0x00000001;
        public const int PSWIZB_NEXT = 0x00000002;
        public const int PSWIZB_FINISH = 0x00000004;
        public const int PSWIZB_DISABLEDFINISH = 0x00000008;
        public const int PSBTN_BACK = 0;
        public const int PSBTN_NEXT = 1;
        public const int PSBTN_FINISH = 2;
        public const int PSBTN_OK = 3;
        public const int PSBTN_APPLYNOW = 4;
        public const int PSBTN_CANCEL = 5;
        public const int PSBTN_HELP = 6;
        public const int PSBTN_MAX = 6;
        public const int ID_PSRESTARTWINDOWS = 0x2;
        public const int WIZ_CXDLG = 276;
        public const int WIZ_CYDLG = 140;
        public const int WIZ_CXBMP = 80;
        public const int WIZ_BODYX = 92;
        public const int WIZ_BODYCX = 184;
        public const int PROP_SM_CXDLG = 212;
        public const int PROP_SM_CYDLG = 188;
        public const int PROP_MED_CXDLG = 227;
        public const int PROP_MED_CYDLG = 215;
        public const int PROP_LG_CXDLG = 252;
        public const int PROP_LG_CYDLG = 218;
        public const int ICC_LISTVIEW_CLASSES = 0x00000001;
        public const int ICC_TREEVIEW_CLASSES = 0x00000002;
        public const int ICC_BAR_CLASSES = 0x00000004;
        public const int ICC_TAB_CLASSES = 0x00000008;
        public const int ICC_UPDOWN_CLASS = 0x00000010;
        public const int ICC_PROGRESS_CLASS = 0x00000020;
        public const int ICC_HOTKEY_CLASS = 0x00000040;
        public const int ICC_ANIMATE_CLASS = 0x00000080;
        public const int ICC_WIN95_CLASSES = 0x000000FF;
        public const int ICC_DATE_CLASSES = 0x00000100;
        public const int ICC_USEREX_CLASSES = 0x00000200;
        public const int ICC_COOL_CLASSES = 0x00000400;
        public const int ICC_INTERNET_CLASSES = 0x00000800;
        public const int ICC_PAGESCROLLER_CLASS = 0x00001000;
        public const int ICC_NATIVEFNTCTL_CLASS = 0x00002000;
        public const int ODT_HEADER = 100;
        public const int ODT_TAB = 101;
        public const int ODT_LISTVIEW = 102;
        public const int LVM_FIRST = 0x1000;
        public const int TV_FIRST = 0x1100;
        public const int HDM_FIRST = 0x1200;
        public const int TCM_FIRST = 0x1300;
        public const int PGM_FIRST = 0x1400;
        public const int CCM_FIRST = 0x2000;
        public const int INFOTIPSIZE = 1024;
        public const int MSGF_COMMCTRL_BEGINDRAG = 0x4200;
        public const int MSGF_COMMCTRL_SIZEHEADER = 0x4201;
        public const int MSGF_COMMCTRL_DRAGSELECT = 0x4202;
        public const int MSGF_COMMCTRL_TOOLBARCUST = 0x4203;
        public const int CDRF_DODEFAULT = 0x00000000;
        public const int CDRF_NEWFONT = 0x00000002;
        public const int CDRF_SKIPDEFAULT = 0x00000004;
        public const int CDRF_NOTIFYPOSTPAINT = 0x00000010;
        public const int CDRF_NOTIFYITEMDRAW = 0x00000020;
        public const int CDRF_NOTIFYSUBITEMDRAW = 0x00000020;
        public const int CDRF_NOTIFYPOSTERASE = 0x00000040;
        public const int CDDS_PREPAINT = 0x00000001;
        public const int CDDS_POSTPAINT = 0x00000002;
        public const int CDDS_PREERASE = 0x00000003;
        public const int CDDS_POSTERASE = 0x00000004;
        public const int CDDS_ITEM = 0x00010000;
        public const int CDDS_SUBITEM = 0x00020000;
        public const int CDIS_SELECTED = 0x0001;
        public const int CDIS_GRAYED = 0x0002;
        public const int CDIS_DISABLED = 0x0004;
        public const int CDIS_CHECKED = 0x0008;
        public const int CDIS_FOCUS = 0x0010;
        public const int CDIS_DEFAULT = 0x0020;
        public const int CDIS_HOT = 0x0040;
        public const int CDIS_MARKED = 0x0080;
        public const int CDIS_INDETERMINATE = 0x0100;
        public const long CLR_NONE = 0xFFFFFFFFL;
        public const long CLR_DEFAULT = 0xFF000000L;
        public const int ILC_MASK = 0x0001;
        public const int ILC_COLOR = 0x0000;
        public const int ILC_COLORDDB = 0x00FE;
        public const int ILC_COLOR4 = 0x0004;
        public const int ILC_COLOR8 = 0x0008;
        public const int ILC_COLOR16 = 0x0010;
        public const int ILC_COLOR24 = 0x0018;
        public const int ILC_COLOR32 = 0x0020;
        public const int ILC_PALETTE = 0x0800;
        public const int ILD_NORMAL = 0x0000;
        public const int ILD_TRANSPARENT = 0x0001;
        public const int ILD_MASK = 0x0010;
        public const int ILD_IMAGE = 0x0020;
        public const int ILD_ROP = 0x0040;
        public const int ILD_BLEND25 = 0x0002;
        public const int ILD_BLEND50 = 0x0004;
        public const int ILD_OVERLAYMASK = 0x0F00;
        public const int ILCF_MOVE = 0x00000000;
        public const int ILCF_SWAP = 0x00000001;
        public const string WC_HEADERA = "SysHeader32";
        public const string WC_HEADER = "SysHeader";
        public const int HDS_HORZ = 0x0000;
        public const int HDS_BUTTONS = 0x0002;
        public const int HDS_HOTTRACK = 0x0004;
        public const int HDS_HIDDEN = 0x0008;
        public const int HDS_DRAGDROP = 0x0040;
        public const int HDS_FULLDRAG = 0x0080;
        public const int HDI_WIDTH = 0x0001;
        public const int HDI_TEXT = 0x0002;
        public const int HDI_FORMAT = 0x0004;
        public const int HDI_LPARAM = 0x0008;
        public const int HDI_BITMAP = 0x0010;
        public const int HDI_IMAGE = 0x0020;
        public const int HDI_DI_SETITEM = 0x0040;
        public const int HDI_ORDER = 0x0080;
        public const int HDF_LEFT = 0;
        public const int HDF_RIGHT = 1;
        public const int HDF_CENTER = 2;
        public const int HDF_JUSTIFYMASK = 0x0003;
        public const int HDF_RTLREADING = 4;
        public const int HDF_OWNERDRAW = 0x8000;
        public const int HDF_STRING = 0x4000;
        public const int HDF_BITMAP = 0x2000;
        public const int HDF_BITMAP_ON_RIGHT = 0x1000;
        public const int HDF_IMAGE = 0x0800;
        public const int HHT_NOWHERE = 0x0001;
        public const int HHT_ONHEADER = 0x0002;
        public const int HHT_ONDIVIDER = 0x0004;
        public const int HHT_ONDIVOPEN = 0x0008;
        public const int HHT_ABOVE = 0x0100;
        public const int HHT_BELOW = 0x0200;
        public const int HHT_TORIGHT = 0x0400;
        public const int HHT_TOLEFT = 0x0800;
        public const string TOOLBARCLASSNAMEA = "ToolbarWindow32";
        public const string TOOLBARCLASSNAME = "ToolbarWindow";
        public const int CMB_MASKED = 0x02;
        public const int TBSTATE_CHECKED = 0x01;
        public const int TBSTATE_PRESSED = 0x02;
        public const int TBSTATE_ENABLED = 0x04;
        public const int TBSTATE_HIDDEN = 0x08;
        public const int TBSTATE_INDETERMINATE = 0x10;
        public const int TBSTATE_WRAP = 0x20;
        public const int TBSTATE_ELLIPSES = 0x40;
        public const int TBSTATE_MARKED = 0x80;
        public const int TBSTYLE_BUTTON = 0x0000;
        public const int TBSTYLE_SEP = 0x0001;
        public const int TBSTYLE_CHECK = 0x0002;
        public const int TBSTYLE_GROUP = 0x0004;
        public const int TBSTYLE_DROPDOWN = 0x0008;
        public const int TBSTYLE_AUTOSIZE = 0x0010;
        public const int TBSTYLE_NOPREFIX = 0x0020;
        public const int TBSTYLE_TOOLTIPS = 0x0100;
        public const int TBSTYLE_WRAPABLE = 0x0200;
        public const int TBSTYLE_ALTDRAG = 0x0400;
        public const int TBSTYLE_FLAT = 0x0800;
        public const int TBSTYLE_LIST = 0x1000;
        public const int TBSTYLE_CUSTOMERASE = 0x2000;
        public const int TBSTYLE_REGISTERDROP = 0x4000;
        public const int TBSTYLE_TRANSPARENT = 0x8000;
        public const int TBSTYLE_EX_DRAWDDARROWS = 0x00000001;
        public const int TBCDRF_NOEDGES = 0x00010000;
        public const int TBCDRF_HILITEHOTTRACK = 0x00020000;
        public const int TBCDRF_NOOFFSET = 0x00040000;
        public const int TBCDRF_NOMARK = 0x00080000;
        public const int TBCDRF_NOETCHEDEFFECT = 0x00100000;
        public const int IDB_STD_SMALL_COLOR = 0;
        public const int IDB_STD_LARGE_COLOR = 1;
        public const int IDB_VIEW_SMALL_COLOR = 4;
        public const int IDB_VIEW_LARGE_COLOR = 5;
        public const int IDB_HIST_SMALL_COLOR = 8;
        public const int IDB_HIST_LARGE_COLOR = 9;
        public const int STD_CUT = 0;
        public const int STD_COPY = 1;
        public const int STD_PASTE = 2;
        public const int STD_UNDO = 3;
        public const int STD_REDOW = 4;
        public const int STD_DELETE = 5;
        public const int STD_FILENEW = 6;
        public const int STD_FILEOPEN = 7;
        public const int STD_FILESAVE = 8;
        public const int STD_PRINTPRE = 9;
        public const int STD_PROPERTIES = 10;
        public const int STD_HELP = 11;
        public const int STD_FIND = 12;
        public const int STD_REPLACE = 13;
        public const int STD_PRINT = 14;
        public const int VIEW_LARGEICONS = 0;
        public const int VIEW_SMALLICONS = 1;
        public const int VIEW_LIST = 2;
        public const int VIEW_DETAILS = 3;
        public const int VIEW_SORTNAME = 4;
        public const int VIEW_SORTSIZE = 5;
        public const int VIEW_SORTDATE = 6;
        public const int VIEW_SORTTYPE = 7;
        public const int VIEW_PARENTFOLDER = 8;
        public const int VIEW_NETCONNECT = 9;
        public const int VIEW_NETDISCONNECT = 10;
        public const int VIEW_NEWFOLDER = 11;
        public const int VIEW_VIEWMENU = 12;
        public const int HIST_BACK = 0;
        public const int HIST_FORWARD = 1;
        public const int HIST_FAVORITES = 2;
        public const int HIST_ADDTOFAVORITES = 3;
        public const int HIST_VIEWTREE = 4;
        public const int TBIMHT_AFTER = 0x00000001;
        public const int TBIMHT_BACKGROUND = 0x00000002;
        public const int TBBF_LARGE = 0x0001;
        public const int TBIF_IMAGE = 0x00000001;
        public const int TBIF_TEXT = 0x00000002;
        public const int TBIF_STATE = 0x00000004;
        public const int TBIF_STYLE = 0x00000008;
        public const int TBIF_LPARAM = 0x00000010;
        public const int TBIF_COMMAND = 0x00000020;
        public const int TBIF_SIZE = 0x00000040;
        public const int HICF_OTHER = 0x00000000;
        public const int HICF_MOUSE = 0x00000001;
        public const int HICF_ARROWKEYS = 0x00000002;
        public const int HICF_ACCELERATOR = 0x00000004;
        public const int HICF_DUPACCEL = 0x00000008;
        public const int HICF_ENTERING = 0x00000010;
        public const int HICF_LEAVING = 0x00000020;
        public const int HICF_RESELECT = 0x00000040;
        public const int TBNF_IMAGE = 0x00000001;
        public const int TBNF_TEXT = 0x00000002;
        public const int TBNF_DI_SETITEM = 0x10000000;
        public const int TBDDRET_DEFAULT = 0;
        public const int TBDDRET_NODEFAULT = 1;
        public const int TBDDRET_TREATPRESSED = 2;
        public const string REBARCLASSNAMEA = "ReBarWindow32";
        public const string REBARCLASSNAME = "ReBarWindow";
        public const int RBIM_IMAGELIST = 0x00000001;
#if RBS_TOOLTIPS_AlternateDefinition1
	public const int RBS_TOOLTIPS = 0x0100;
#elif RBS_TOOLTIPS_AlternateDefinition2
	public const int RBS_TOOLTIPS = 0x00000100;
#endif
#if RBS_VARHEIGHT_AlternateDefinition1
	public const int RBS_VARHEIGHT = 0x0200;
#elif RBS_VARHEIGHT_AlternateDefinition2
	public const int RBS_VARHEIGHT = 0x00000200;
#endif
#if RBS_BANDBORDERS_AlternateDefinition1
	public const int RBS_BANDBORDERS = 0x0400;
#elif RBS_BANDBORDERS_AlternateDefinition2
	public const int RBS_BANDBORDERS = 0x00000400;
#endif
#if RBS_FIXEDORDER_AlternateDefinition1
	public const int RBS_FIXEDORDER = 0x0800;
#elif RBS_FIXEDORDER_AlternateDefinition2
	public const int RBS_FIXEDORDER = 0x00000800;
#endif
        public const int RBS_REGISTERDROP = 0x1000;
        public const int RBS_AUTOSIZE = 0x2000;
        public const int RBS_VERTICALGRIPPER = 0x4000;
        public const int RBS_DBLCLKTOGGLE = 0x8000;
        public const int RBBS_BREAK = 0x00000001;
        public const int RBBS_FIXEDSIZE = 0x00000002;
        public const int RBBS_CHILDEDGE = 0x00000004;
        public const int RBBS_HIDDEN = 0x00000008;
        public const int RBBS_NOVERT = 0x00000010;
        public const int RBBS_FIXEDBMP = 0x00000020;
        public const int RBBS_VARIABLEHEIGHT = 0x00000040;
        public const int RBBS_GRIPPERALWAYS = 0x00000080;
        public const int RBBS_NOGRIPPER = 0x00000100;
        public const int RBBIM_STYLE = 0x00000001;
        public const int RBBIM_COLORS = 0x00000002;
        public const int RBBIM_TEXT = 0x00000004;
        public const int RBBIM_IMAGE = 0x00000008;
        public const int RBBIM_CHILD = 0x00000010;
        public const int RBBIM_CHILDSIZE = 0x00000020;
        public const int RBBIM_SIZE = 0x00000040;
        public const int RBBIM_BACKGROUND = 0x00000080;
        public const int RBBIM_ID = 0x00000100;
        public const int RBBIM_IDEALSIZE = 0x00000200;
        public const int RBBIM_LPARAM = 0x00000400;
        public const int RBBIM_HEADERSIZE = 0x00000800;
        public const int RBNM_ID = 0x00000001;
        public const int RBNM_STYLE = 0x00000002;
        public const int RBNM_LPARAM = 0x00000004;
        public const int RBHT_NOWHERE = 0x0001;
        public const int RBHT_CAPTION = 0x0002;
        public const int RBHT_CLIENT = 0x0003;
        public const int RBHT_GRABBER = 0x0004;
        public const string TOOLTIPS_CLASSA = "tooltips_class32";
        public const string TOOLTIPS_CLASS = "tooltips_class";
        public const int TTS_ALWAYSTIP = 0x01;
        public const int TTS_NOPREFIX = 0x02;
        public const int TTF_IDISHWND = 0x0001;
        public const int TTF_CENTERTIP = 0x0002;
        public const int TTF_RTLREADING = 0x0004;
        public const int TTF_SUBCLASS = 0x0010;
        public const int TTF_TRACK = 0x0020;
        public const int TTF_ABSOLUTE = 0x0080;
        public const int TTF_TRANSPARENT = 0x0100;
        public const int TTF_DI_SETITEM = 0x8000;
        public const int TTDT_AUTOMATIC = 0;
        public const int TTDT_RESHOW = 1;
        public const int TTDT_AUTOPOP = 2;
        public const int TTDT_INITIAL = 3;
        public const int SBARS_SIZEGRIP = 0x0100;
        public const string STATUSCLASSNAMEA = "msctls_statusbar32";
        public const string STATUSCLASSNAME = "msctls_statusbar";
        public const int SBT_OWNERDRAW = 0x1000;
        public const int SBT_NOBORDERS = 0x0100;
        public const int SBT_POPOUT = 0x0200;
        public const int SBT_RTLREADING = 0x0400;
        public const int SBT_TOOLTIPS = 0x0800;
        public const string TRACKBAR_CLASSA = "msctls_trackbar32";
        public const string TRACKBAR_CLASS = "msctls_trackbar";
        public const int TBS_AUTOTICKS = 0x0001;
        public const int TBS_VERT = 0x0002;
        public const int TBS_HORZ = 0x0000;
        public const int TBS_TOP = 0x0004;
        public const int TBS_BOTTOM = 0x0000;
        public const int TBS_LEFT = 0x0004;
        public const int TBS_RIGHT = 0x0000;
        public const int TBS_BOTH = 0x0008;
        public const int TBS_NOTICKS = 0x0010;
        public const int TBS_ENABLESELRANGE = 0x0020;
        public const int TBS_FIXEDLENGTH = 0x0040;
        public const int TBS_NOTHUMB = 0x0080;
        public const int TBS_TOOLTIPS = 0x0100;
        public const int TBTS_TOP = 0;
        public const int TBTS_LEFT = 1;
        public const int TBTS_BOTTOM = 2;
        public const int TBTS_RIGHT = 3;
        public const int TB_LINEUP = 0;
        public const int TB_LINEDOWN = 1;
        public const int TB_PAGEUP = 2;
        public const int TB_PAGEDOWN = 3;
        public const int TB_THUMBPOSITION = 4;
        public const int TB_THUMBTRACK = 5;
        public const int TB_TOP = 6;
        public const int TB_BOTTOM = 7;
        public const int TB_ENDTRACK = 8;
        public const int TBCD_TICS = 0x0001;
        public const int TBCD_THUMB = 0x0002;
        public const int TBCD_CHANNEL = 0x0003;
        public const int DL_CURSORSET = 0;
        public const int DL_STOPCURSOR = 1;
        public const int DL_COPYCURSOR = 2;
        public const int DL_MOVECURSOR = 3;
        public const string UPDOWN_CLASSA = "msctls_updown32";
        public const string UPDOWN_CLASS = "msctls_updown";
        public const int UD_MAXVAL = 0x7fff;
        public const int UDS_WRAP = 0x0001;
        public const int UDS_SETBUDDYINT = 0x0002;
        public const int UDS_ALIGNRIGHT = 0x0004;
        public const int UDS_ALIGNLEFT = 0x0008;
        public const int UDS_AUTOBUDDY = 0x0010;
        public const int UDS_ARROWKEYS = 0x0020;
        public const int UDS_HORZ = 0x0040;
        public const int UDS_NOTHOUSANDS = 0x0080;
        public const int UDS_HOTTRACK = 0x0100;
        public const string PROGRESS_CLASSA = "msctls_progress32";
        public const string PROGRESS_CLASS = "msctls_progress";
        public const int PBS_SMOOTH = 0x01;
        public const int PBS_VERTICAL = 0x04;
        public const int HOTKEYF_SHIFT = 0x01;
        public const int HOTKEYF_CONTROL = 0x02;
        public const int HOTKEYF_ALT = 0x04;
#if HOTKEYF_EXT_AlternateDefinition1
	public const int HOTKEYF_EXT = 0x80;
#elif HOTKEYF_EXT_AlternateDefinition2
	public const int HOTKEYF_EXT = 0x08;
#endif
        public const int HKCOMB_NONE = 0x0001;
        public const int HKCOMB_S = 0x0002;
        public const int HKCOMB_C = 0x0004;
        public const int HKCOMB_A = 0x0008;
        public const int HKCOMB_SC = 0x0010;
        public const int HKCOMB_SA = 0x0020;
        public const int HKCOMB_CA = 0x0040;
        public const int HKCOMB_SCA = 0x0080;
        public const string HOTKEY_CLASSA = "msctls_hotkey32";
        public const string HOTKEY_CLASS = "msctls_hotkey";
        public const long CCS_TOP = 0x00000001L;
        public const long CCS_NOMOVEY = 0x00000002L;
        public const long CCS_BOTTOM = 0x00000003L;
        public const long CCS_NORESIZE = 0x00000004L;
        public const long CCS_NOPARENTALIGN = 0x00000008L;
        public const long CCS_ADJUSTABLE = 0x00000020L;
        public const long CCS_NODIVIDER = 0x00000040L;
        public const long CCS_VERT = 0x00000080L;
        public const string WC_LISTVIEWA = "SysListView32";
        public const string WC_LISTVIEW = "SysListView";
        public const int LVS_ICON = 0x0000;
        public const int LVS_REPORT = 0x0001;
        public const int LVS_SMALLICON = 0x0002;
        public const int LVS_LIST = 0x0003;
        public const int LVS_TYPEMASK = 0x0003;
        public const int LVS_SINGLESEL = 0x0004;
        public const int LVS_SHOWSELALWAYS = 0x0008;
        public const int LVS_SORTASCENDING = 0x0010;
        public const int LVS_SORTDESCENDING = 0x0020;
        public const int LVS_SHAREIMAGELISTS = 0x0040;
        public const int LVS_NOLABELWRAP = 0x0080;
        public const int LVS_AUTOARRANGE = 0x0100;
        public const int LVS_EDITLABELS = 0x0200;
        public const int LVS_OWNERDATA = 0x1000;
        public const int LVS_NOSCROLL = 0x2000;
        public const int LVS_TYPESTYLEMASK = 0xfc00;
        public const int LVS_ALIGNTOP = 0x0000;
        public const int LVS_ALIGNLEFT = 0x0800;
        public const int LVS_ALIGNMASK = 0x0c00;
        public const int LVS_OWNERDRAWFIXED = 0x0400;
        public const int LVS_NOCOLUMNHEADER = 0x4000;
        public const int LVS_NOSORTHEADER = 0x8000;
        public const int LVSIL_NORMAL = 0;
        public const int LVSIL_SMALL = 1;
        public const int LVSIL_STATE = 2;
        public const int LVIF_TEXT = 0x0001;
        public const int LVIF_IMAGE = 0x0002;
        public const int LVIF_PARAM = 0x0004;
        public const int LVIF_STATE = 0x0008;
        public const int LVIF_INDENT = 0x0010;
        public const int LVIF_NORECOMPUTE = 0x0800;
        public const int LVIS_FOCUSED = 0x0001;
        public const int LVIS_SELECTED = 0x0002;
        public const int LVIS_CUT = 0x0004;
        public const int LVIS_DROPHILITED = 0x0008;
        public const int LVIS_ACTIVATING = 0x0020;
        public const int LVIS_OVERLAYMASK = 0x0F00;
        public const int LVIS_STATEIMAGEMASK = 0xF000;
        public const int LVNI_ALL = 0x0000;
        public const int LVNI_FOCUSED = 0x0001;
        public const int LVNI_SELECTED = 0x0002;
        public const int LVNI_CUT = 0x0004;
        public const int LVNI_DROPHILITED = 0x0008;
        public const int LVNI_ABOVE = 0x0100;
        public const int LVNI_BELOW = 0x0200;
        public const int LVNI_TOLEFT = 0x0400;
        public const int LVNI_TORIGHT = 0x0800;
        public const int LVFI_PARAM = 0x0001;
        public const int LVFI_STRING = 0x0002;
        public const int LVFI_PARTIAL = 0x0008;
        public const int LVFI_WRAP = 0x0020;
        public const int LVFI_NEARESTXY = 0x0040;
        public const int LVIR_BOUNDS = 0;
        public const int LVIR_ICON = 1;
        public const int LVIR_LABEL = 2;
        public const int LVIR_SELECTBOUNDS = 3;
        public const int LVHT_NOWHERE = 0x0001;
        public const int LVHT_ONITEMICON = 0x0002;
        public const int LVHT_ONITEMLABEL = 0x0004;
        public const int LVHT_ONITEMSTATEICON = 0x0008;
        public const int LVHT_ABOVE = 0x0008;
        public const int LVHT_BELOW = 0x0010;
        public const int LVHT_TORIGHT = 0x0020;
        public const int LVHT_TOLEFT = 0x0040;
        public const int LVA_DEFAULT = 0x0000;
        public const int LVA_ALIGNLEFT = 0x0001;
        public const int LVA_ALIGNTOP = 0x0002;
        public const int LVA_SNAPTOGRID = 0x0005;
        public const int LVCF_FMT = 0x0001;
        public const int LVCF_WIDTH = 0x0002;
        public const int LVCF_TEXT = 0x0004;
        public const int LVCF_SUBITEM = 0x0008;
        public const int LVCF_IMAGE = 0x0010;
        public const int LVCF_ORDER = 0x0020;
        public const int LVCFMT_LEFT = 0x0000;
        public const int LVCFMT_RIGHT = 0x0001;
        public const int LVCFMT_CENTER = 0x0002;
        public const int LVCFMT_JUSTIFYMASK = 0x0003;
        public const int LVCFMT_IMAGE = 0x0800;
        public const int LVCFMT_BITMAP_ON_RIGHT = 0x1000;
        public const int LVCFMT_COL_HAS_IMAGES = 0x8000;
        public const int LVSICF_NOINVALIDATEALL = 0x00000001;
        public const int LVSICF_NOSCROLL = 0x00000002;
        public const int LVS_EX_GRIDLINES = 0x00000001;
        public const int LVS_EX_SUBITEMIMAGES = 0x00000002;
        public const int LVS_EX_CHECKBOXES = 0x00000004;
        public const int LVS_EX_TRACKSELECT = 0x00000008;
        public const int LVS_EX_HEADERDRAGDROP = 0x00000010;
        public const int LVS_EX_FULLROWSELECT = 0x00000020;
        public const int LVS_EX_ONECLICKACTIVATE = 0x00000040;
        public const int LVS_EX_TWOCLICKACTIVATE = 0x00000080;
        public const int LVS_EX_FLATSB = 0x00000100;
        public const int LVS_EX_REGIONAL = 0x00000200;
        public const int LVS_EX_INFOTIP = 0x00000400;
        public const int LVS_EX_UNDERLINEHOT = 0x00000800;
        public const int LVS_EX_UNDERLINECOLD = 0x00001000;
        public const int LVS_EX_MULTIWORKAREAS = 0x00002000;
        public const int LV_MAX_WORKAREAS = 16;
        public const int LVBKIF_SOURCE_NONE = 0x00000000;
        public const int LVBKIF_SOURCE_HBITMAP = 0x00000001;
        public const int LVBKIF_SOURCE_URL = 0x00000002;
        public const int LVBKIF_SOURCE_MASK = 0x00000003;
        public const int LVBKIF_STYLE_NORMAL = 0x00000000;
        public const int LVBKIF_STYLE_TILE = 0x00000010;
        public const int LVBKIF_STYLE_MASK = 0x00000010;
        public const int LVKF_ALT = 0x0001;
        public const int LVKF_CONTROL = 0x0002;
        public const int LVKF_SHIFT = 0x0004;
        public const int LVIF_DI_SETITEM = 0x1000;
        public const int LVGIT_UNFOLDED = 0x0001;
        public const string WC_TREEVIEWA = "SysTreeView32";
        public const string WC_TREEVIEW = "SysTreeView";
        public const int TVS_HASBUTTONS = 0x0001;
        public const int TVS_HASLINES = 0x0002;
        public const int TVS_LINESATROOT = 0x0004;
        public const int TVS_EDITLABELS = 0x0008;
        public const int TVS_DISABLEDRAGDROP = 0x0010;
        public const int TVS_SHOWSELALWAYS = 0x0020;
        public const int TVS_RTLREADING = 0x0040;
        public const int TVS_NOTOOLTIPS = 0x0080;
        public const int TVS_CHECKBOXES = 0x0100;
        public const int TVS_TRACKSELECT = 0x0200;
        public const int TVS_SINGLEEXPAND = 0x0400;
        public const int TVS_INFOTIP = 0x0800;
        public const int TVS_FULLROWSELECT = 0x1000;
        public const int TVS_NOSCROLL = 0x2000;
        public const int TVS_NONEVENHEIGHT = 0x4000;
        public const int TVIF_TEXT = 0x0001;
        public const int TVIF_IMAGE = 0x0002;
        public const int TVIF_PARAM = 0x0004;
        public const int TVIF_STATE = 0x0008;
        public const int TVIF_HANDLE = 0x0010;
        public const int TVIF_SELECTEDIMAGE = 0x0020;
        public const int TVIF_CHILDREN = 0x0040;
        public const int TVIF_INTEGRAL = 0x0080;
        public const int TVIS_SELECTED = 0x0002;
        public const int TVIS_CUT = 0x0004;
        public const int TVIS_DROPHILITED = 0x0008;
        public const int TVIS_BOLD = 0x0010;
        public const int TVIS_EXPANDED = 0x0020;
        public const int TVIS_EXPANDEDONCE = 0x0040;
        public const int TVIS_EXPANDPARTIAL = 0x0080;
        public const int TVIS_OVERLAYMASK = 0x0F00;
        public const int TVIS_STATEIMAGEMASK = 0xF000;
        public const int TVIS_USERMASK = 0xF000;
        public const int TVE_COLLAPSE = 0x0001;
        public const int TVE_EXPAND = 0x0002;
        public const int TVE_TOGGLE = 0x0003;
        public const int TVE_EXPANDPARTIAL = 0x4000;
        public const int TVE_COLLAPSERESET = 0x8000;
        public const int TVSIL_NORMAL = 0;
        public const int TVSIL_STATE = 2;
        public const int TVGN_ROOT = 0x0000;
        public const int TVGN_NEXT = 0x0001;
        public const int TVGN_PREVIOUS = 0x0002;
        public const int TVGN_PARENT = 0x0003;
        public const int TVGN_CHILD = 0x0004;
        public const int TVGN_FIRSTVISIBLE = 0x0005;
        public const int TVGN_NEXTVISIBLE = 0x0006;
        public const int TVGN_PREVIOUSVISIBLE = 0x0007;
        public const int TVGN_DROPHILITE = 0x0008;
        public const int TVGN_CARET = 0x0009;
        public const int TVGN_LASTVISIBLE = 0x000A;
        public const int TVHT_NOWHERE = 0x0001;
        public const int TVHT_ONITEMICON = 0x0002;
        public const int TVHT_ONITEMLABEL = 0x0004;
        public const int TVHT_ONITEMINDENT = 0x0008;
        public const int TVHT_ONITEMBUTTON = 0x0010;
        public const int TVHT_ONITEMRIGHT = 0x0020;
        public const int TVHT_ONITEMSTATEICON = 0x0040;
        public const int TVHT_ABOVE = 0x0100;
        public const int TVHT_BELOW = 0x0200;
        public const int TVHT_TORIGHT = 0x0400;
        public const int TVHT_TOLEFT = 0x0800;
        public const int TVC_UNKNOWN = 0x0000;
        public const int TVC_BYMOUSE = 0x0001;
        public const int TVC_BYKEYBOARD = 0x0002;
        public const int TVIF_DI_SETITEM = 0x1000;
        public const int TVCDRF_NOIMAGES = 0x00010000;
        public const string WC_COMBOBOXEXA = "ComboBoxEx32";
        public const int CBEIF_TEXT = 0x00000001;
        public const int CBEIF_IMAGE = 0x00000002;
        public const int CBEIF_SELECTEDIMAGE = 0x00000004;
        public const int CBEIF_OVERLAY = 0x00000008;
        public const int CBEIF_INDENT = 0x00000010;
        public const int CBEIF_LPARAM = 0x00000020;
        public const int CBEIF_DI_SETITEM = 0x10000000;
        public const int CBES_EX_NOEDITIMAGE = 0x00000001;
        public const int CBES_EX_NOEDITIMAGEINDENT = 0x00000002;
        public const int CBES_EX_PATHWORDBREAKPROC = 0x00000004;
        public const int CBES_EX_NOSIZELIMIT = 0x00000008;
        public const int CBES_EX_CASESENSITIVE = 0x00000010;
        public const int CBENF_KILLFOCUS = 1;
        public const int CBENF_RETURN = 2;
        public const int CBENF_ESCAPE = 3;
        public const int CBENF_DROPDOWN = 4;
        public const int CBEMAXSTRLEN = 260;
        public const string WC_TABCONTROLA = "SysTabControl32";
        public const string WC_TABCONTROL = "SysTabControl";
        public const int TCS_SCROLLOPPOSITE = 0x0001;
        public const int TCS_BOTTOM = 0x0002;
        public const int TCS_RIGHT = 0x0002;
        public const int TCS_MULTISELECT = 0x0004;
        public const int TCS_FLATBUTTONS = 0x0008;
        public const int TCS_FORCEICONLEFT = 0x0010;
        public const int TCS_FORCELABELLEFT = 0x0020;
        public const int TCS_HOTTRACK = 0x0040;
        public const int TCS_VERTICAL = 0x0080;
        public const int TCS_TABS = 0x0000;
        public const int TCS_BUTTONS = 0x0100;
        public const int TCS_SINGLELINE = 0x0000;
        public const int TCS_MULTILINE = 0x0200;
        public const int TCS_RIGHTJUSTIFY = 0x0000;
        public const int TCS_FIXEDWIDTH = 0x0400;
        public const int TCS_RAGGEDRIGHT = 0x0800;
        public const int TCS_FOCUSONBUTTONDOWN = 0x1000;
        public const int TCS_OWNERDRAWFIXED = 0x2000;
        public const int TCS_TOOLTIPS = 0x4000;
        public const int TCS_FOCUSNEVER = 0x8000;
        public const int TCS_EX_FLATSEPARATORS = 0x00000001;
        public const int TCS_EX_REGISTERDROP = 0x00000002;
        public const int TCIF_TEXT = 0x0001;
        public const int TCIF_IMAGE = 0x0002;
        public const int TCIF_RTLREADING = 0x0004;
        public const int TCIF_PARAM = 0x0008;
        public const int TCIF_STATE = 0x0010;
        public const int TCIS_BUTTONPRESSED = 0x0001;
        public const int TCIS_HIGHLIGHTED = 0x0002;
        public const int TCHT_NOWHERE = 0x0001;
        public const int TCHT_ONITEMICON = 0x0002;
        public const int TCHT_ONITEMLABEL = 0x0004;
        public const string ANIMATE_CLASSA = "SysAnimate32";
        public const int ACS_CENTER = 0x0001;
        public const int ACS_TRANSPARENT = 0x0002;
        public const int ACS_AUTOPLAY = 0x0004;
        public const int ACS_TIMER = 0x0008;
        public const int ACN_START = 1;
        public const int ACN_STOP = 2;
        public const string MONTHCAL_CLASSA = "SysMonthCal32";
        public const int MCM_FIRST = 0x1000;
        public const int MCSC_BACKGROUND = 0;
        public const int MCSC_TEXT = 1;
        public const int MCSC_TITLEBK = 2;
        public const int MCSC_TITLETEXT = 3;
        public const int MCSC_MONTHBK = 4;
        public const int MCSC_TRAILINGTEXT = 5;
        public const int MCHT_TITLE = 0x00010000;
        public const int MCHT_CALENDAR = 0x00020000;
        public const int MCHT_TODAYLINK = 0x00030000;
        public const int MCHT_NEXT = 0x01000000;
        public const int MCHT_PREV = 0x02000000;
        public const int MCHT_NOWHERE = 0x00000000;
        public const int MCS_DAYSTATE = 0x0001;
        public const int MCS_MULTISELECT = 0x0002;
        public const int MCS_WEEKNUMBERS = 0x0004;
        public const int MCS_NOTODAYCIRCLE = 0x0008;
#if MCS_NOTODAY_AlternateDefinition1
	public const int MCS_NOTODAY = 0x0010;
#elif MCS_NOTODAY_AlternateDefinition2
	public const int MCS_NOTODAY = 0x0008;
#endif
        public const int GMR_VISIBLE = 0;
        public const int GMR_DAYSTATE = 1;
        public const string DATETIMEPICK_CLASSA = "SysDateTimePick32";
        public const int DTM_FIRST = 0x1000;
        public const int DTS_UPDOWN = 0x0001;
        public const int DTS_SHOWNONE = 0x0002;
        public const int DTS_SHORTDATEFORMAT = 0x0000;
        public const int DTS_LONGDATEFORMAT = 0x0004;
        public const int DTS_TIMEFORMAT = 0x0009;
        public const int DTS_APPCANPARSE = 0x0010;
        public const int DTS_RIGHTALIGN = 0x0020;
        public const int GDTR_MIN = 0x0001;
        public const int GDTR_MAX = 0x0002;
        public const int GDT_VALID = 0;
        public const int GDT_NONE = 1;
        public const string WC_IPADDRESSA = "SysIPAddress32";
        public const string WC_PAGESCROLLERA = "SysPager";
        public const int PGS_VERT = 0x00000000;
        public const int PGS_HORZ = 0x00000001;
        public const int PGS_AUTOSCROLL = 0x00000002;
        public const int PGS_DRAGNDROP = 0x00000004;
        public const int PGF_INVISIBLE = 0;
        public const int PGF_NORMAL = 1;
        public const int PGF_GRAYED = 2;
        public const int PGF_DEPRESSED = 4;
        public const int PGF_HOT = 8;
        public const int PGB_TOPORLEFT = 0;
        public const int PGB_BOTTOMORRIGHT = 1;
        public const int PGF_SCROLLUP = 1;
        public const int PGF_SCROLLDOWN = 2;
        public const int PGF_SCROLLLEFT = 4;
        public const int PGF_SCROLLRIGHT = 8;
        public const int PGK_SHIFT = 1;
        public const int PGK_CONTROL = 2;
        public const int PGK_MENU = 4;
        public const int PGF_CALCWIDTH = 1;
        public const int PGF_CALCHEIGHT = 2;
        public const string WC_NATIVEFONTCTLA = "NativeFontCtl";
        public const int NFS_EDIT = 0x0001;
        public const int NFS_STATIC = 0x0002;
        public const int NFS_LISTCOMBO = 0x0004;
        public const int NFS_BUTTON = 0x0008;
        public const int NFS_ALL = 0x0010;
        public const int WM_MOUSEHOVER = 0x02A1;
        public const int WM_MOUSELEAVE = 0x02A3;
        public const int TME_HOVER = 0x00000001;
        public const int TME_LEAVE = 0x00000002;
        public const int TME_QUERY = 0x40000000;
        public const long TME_CANCEL = 0x80000000;
        public const long HOVER_DEFAULT = 0xFFFFFFFF;
        public const long WSB_PROP_CYVSCROLL = 0x00000001L;
        public const long WSB_PROP_CXHSCROLL = 0x00000002L;
        public const long WSB_PROP_CYHSCROLL = 0x00000004L;
        public const long WSB_PROP_CXVSCROLL = 0x00000008L;
        public const long WSB_PROP_CXHTHUMB = 0x00000010L;
        public const long WSB_PROP_CYVTHUMB = 0x00000020L;
        public const long WSB_PROP_VBKGCOLOR = 0x00000040L;
        public const long WSB_PROP_HBKGCOLOR = 0x00000080L;
        public const long WSB_PROP_VSTYLE = 0x00000100L;
        public const long WSB_PROP_HSTYLE = 0x00000200L;
        public const long WSB_PROP_WINSTYLE = 0x00000400L;
        public const long WSB_PROP_PALETTE = 0x00000800L;
        public const long WSB_PROP_MASK = 0x00000FFFL;
        public const int FSB_FLAT_MODE = 2;
        public const int FSB_ENCARTA_MODE = 1;
        public const int FSB_REGULAR_MODE = 0;
        public const int _MS = 0x01;
        public const int _MP = 0x02;
        public const int _M1 = 0x04;
        public const int _M2 = 0x08;
        public const int _SBUP = 0x10;
        public const int _SBLOW = 0x20;
        public const int _MBC_SINGLE = 0;
        public const int _MBC_LEAD = 1;
        public const int _MBC_TRAIL = 2;
        public const int _KANJI_CP = 932;
        public const int _MB_CP_SBCS = 0;
        public const int _NLSCMPERROR = 2147483647;
        public const int WM_CTLCOLOR = 0x0019;
#if _AFX_PACKING_AlternateDefinition1
	public const int _AFX_PACKING = 8;
#elif _AFX_PACKING_AlternateDefinition2
	public const int _AFX_PACKING = 4;
#endif
        public const int VK_KANA = 0x15;
        public const int NULL = 0;
        public const int _CRT_WARN = 0;
        public const int _CRT_ERROR = 1;
        public const int _CRT_ASSERT = 2;
        public const int _CRT_ERRCNT = 3;
        public const int _CRTDBG_MODE_FILE = 0x1;
        public const int _CRTDBG_MODE_DEBUG = 0x2;
        public const int _CRTDBG_MODE_WNDW = 0x4;
        public const int _HOOK_ALLOC = 1;
        public const int _HOOK_REALLOC = 2;
        public const int _HOOK_FREE = 3;
        public const int _CRTDBG_ALLOC_MEM_DF = 0x01;
        public const int _CRTDBG_DELAY_FREE_MEM_DF = 0x02;
        public const int _CRTDBG_CHECK_ALWAYS_DF = 0x04;
        public const int _CRTDBG_RESERVED_DF = 0x08;
        public const int _CRTDBG_CHECK_CRT_DF = 0x10;
        public const int _CRTDBG_LEAK_CHECK_DF = 0x20;
        public const int _FREE_BLOCK = 0;
        public const int _NORMAL_BLOCK = 1;
        public const int _CRT_BLOCK = 2;
        public const int _IGNORE_BLOCK = 3;
        public const int _CLIENT_BLOCK = 4;
        public const int _MAX_BLOCKS = 5;
        public const int FALSE = 0;
        public const int TRUE = 1;
        public const long VERSIONABLE_SCHEMA = 0x80000000;
        public const int AFX_STACK_DUMP_TARGET_TRACE = 0x0001;
        public const int AFX_STACK_DUMP_TARGET_CLIPBOARD = 0x0002;
        public const int AFX_STACK_DUMP_TARGET_BOTH = 0x0003;
        public const int AFX_STACK_DUMP_TARGET_ODS = 0x0004;
        public const int WH_DRAW_POINT = 1;
        public const int WH_DRAW_LINE = 2;
        public const int WH_DRAW_ARC = 3;
        public const int WH_DRAW_CIRCLE = 4;
        public const int WH_DRAW_RECT = 5;
        public const int WH_DRAW_ELLIPSE = 6;
        public const int WH_DRAW_SPLINE = 7;
        public const int WH_DRAW_POLY = 8;
        public const int WH_DRAW_TEXT = 9;
        public const int WH_DRAW_FILL = 10;
        public const int WH_DRAW_SURFACE = 11;
        public const int WH_DRAW_GRID = 12;
        public const int WH_RED = 30;
        public const int WH_GREEN = 31;
        public const int WH_BLUE = 32;
        public const int WH_PEN_SOLID = 40;
        public const int WH_PEN_DASH = 41;
        public const int WH_PEN_DOT = 42;
        public const int WH_PEN_DASHDOT = 43;
        public const int WH_BRUSH_SOLID = 50;
        public const int WH_BRUSH_TRANSPARENT = 51;
        public const int WH_SELECT = 100;
        public const int WH_MOVE = 101;
        public const int WH_COPY = 102;
        public const int WH_DELETE = 103;
        public const int WH_DELETE_ALL = 104;
        public const int WH_MIRROR = 105;
        public const int WH_ZOOM = 106;
        public const int WH_TYPE_LAYER = 1000;
        public const int WH_TYPE_GROUP = 1001;
        public const int WH_TYPE_BLOCK = 1002;
        public const int WH_TYPE_PINTD = 1003;
        public const int WH_TYPE_LINE = 1004;
        public const int WH_TYPE_LINED = 1005;
        public const int WH_TYPE_ARC = 1006;
        public const int WH_TYPE_ARCD = 1007;
        public const int WH_TYPE_RECTD = 1008;
        public const int WH_TYPE_POLYLINE = 1009;
        public const int WH_TYPE_ELLIPSE = 1010;
        public const int WH_TYPE_GRID = 1011;
        public const int WH_MODIFY_LINE = 2000;
        public const int WH_MODIFY_ARC = 2001;
        public const int WH_MODIFY_ELLIPSE = 2002;
        public const int WH_MODIFY_GROUP = 2003;
        public const int WH_HAND_TRANSFORM = 3000;
        public const int WH_AUTO_TRANSFORM = 3001;
        public const double PI = 3.14159265358979323846;
        public const double TRANSRATIO = 1000.0;
    }
    public class DefineTypes:CWhVirtual
    {
        //----------------------------------------------------------------------
        public struct tagWHY_SEG
        {
            long fX;
            long fY;
            bool bIsUsed;
            unsafe tagWHY_SEG* pPrev;
            unsafe tagWHY_SEG* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_SEG_LIST
        {
            unsafe tagWHY_SEG pHeadSeg;
            unsafe tagWHY_SEG_LIST* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_FREE_MAN
        {
            long nObjectLabel;
            long nStartX;
            long nStartY;
            long nStepNum;
            bool bIsOutBorder;
            long pXChain;
            long pYChain;
            Byte pChain;
            unsafe tagWHY_FREE_MAN* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_RUN_LEN
        {
            long nStartX;
            long nEndX;
            long nLabel;
            long nLeftLabel;
            long nRightLabel;
            long nUpNum;
            long nDownNum;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_RUN_LIST
        {
            long nSegNum;
            unsafe tagWHY_RUN_LEN pHead;
        };


        //----------------------------------------------------------------------
        // Run Length Label List
        public struct tagWHY_RUN_LABEL
        {
            long nLabel;
            long nNewLabel;
            unsafe tagWHY_RUN_LABEL* pNewRunLabel;
            unsafe tagWHY_RUN_LABEL* pNext;
        };


        //----------------------------------------------------------------------
        // Chain Code Segment 
        // The ChainCode with the Same Direction Will Be Merged
        public struct tagWHY_CHAIN_SEG
        {
            Byte nDir;
            long nLen;
            unsafe tagWHY_CHAIN_SEG* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_CHAIN
        {
            long nStartX;
            long nStartY;
            long nObjectLabel;
            long nStepNum;
            long nPrevLabel;
            long nNextLabel;
            Byte nUsedTimes;
            bool bIsTop;

            // used only when m_bTraceMethod==TRUE
            long nMemNum;
            Byte pChain;

            // used only when m_bTraceMethod==FALSE
            tagWHY_CHAIN_SEG pHeadChainSeg;
            tagWHY_CHAIN_SEG pTailChainSeg;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_CHAIN_LIST
        {
            long nStartX;
            long nStartY;
            long nPointNum;
            long pXChain;
            long pYChain;
            Byte pChain;

        };


        //----------------------------------------------------------------------
        public struct tagWHY_PITCH
        {
            long nLabel;
            //double		M00,M01,M10,M11,M02,M20;
            float fA, fB, fC;
            float fXc, fYc;
            float fAngle;
            float fWidth;
            float fArea;
            unsafe tagWHY_PITCH* pNext;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_LINE
        {
            float fA, fB, fC;
            float fXc, fYc;
            float fWidth;
        };


        //----------------------------------------------------------------------
        public struct tagWHY_LINE_SEG
        {
            long nStartX;
            long nStartY;
            long nEndX;
            long nEndY;
            unsafe tagWHY_LINE_SEG* pNext;
        };


        //----------------------------------------------------------------
        public struct tagWHY_REGION
        {
            long nRegionType;
            long nPointNum;
            POINTD pPointList;
        };


        //----------------------------------------------------------------
        public struct tagWHY_POINT_OBJECT
        {
            long nPointType;
            tagWHY_REGION pRegion1;
            tagWHY_REGION pRegion2;
        };


        //----------------------------------------------------------------
        public struct tagWHY_LINE_OBJECT
        {
            long nLineType;
            tagWHY_REGION pRegion1;
            tagWHY_REGION pRegion2;
        };


        //----------------------------------------------------------------
        public struct tagWHY_INSTRUCTION
        {
            long nMeasureType;

            tagWHY_REGION pRegion;
            tagWHY_POINT_OBJECT pPointObject1;
            tagWHY_LINE_OBJECT pLineObject1;

            tagWHY_POINT_OBJECT pPointObject2;
            tagWHY_LINE_OBJECT pLineObject2;

            unsafe tagWHY_INSTRUCTION* pNext;
        };


        public struct tagWHY_FEATURE
        {
            long nLabel;
            long nHoleNum;

            double fXc, fYc;
            double fA, fB, fC;
            double fAngle;
            double fArea;
            double fPerimeter;
            tagWHY_RUN_LEN pRunLen;
            tagWHY_FREE_MAN pOuterHeadFreeMan;
            tagWHY_FREE_MAN pInnerHeadFreeMan;
            unsafe tagWHY_FEATURE* pNext;
        };


        // This structure for passing data into LineDDA
        public struct tagWHY_PTS
        {
            long nPos;
            LPPOINTD lpPoints;
        };

        // This structure for passing data into LineDDA
        public struct tagWHY_PTS2
        {
            long nPos;
            long pXList;
            long pYList;
        };

        public struct tagWHY_FILTER
        {
            short nMethod;
            short ppMask;
            short nMaskSize;
            short nOrientation;
            short nStrength;
            float fVariant;
            float fAngle;
            float fAlpha;
            float fMean;
            float fPeriod;
            unsafe fixed char Reserve[32];
        };


        public struct tagWHY_SIGMA
        {
            bool bFlag;
            double fS00;
            double fS10;
            double fS01;
            double fS20;
            double fS11;
            double fS02;
            double fS30;
            double fS21;
            double fS12;
            double fS03;
        };


        // float 
        public struct tagRECTF
        {
            float left;
            float top;
            float right;
            float bottom;
        };

        public struct RECTF
        {
            float left;
            float top;
            float right;
            float bottom;
        };
        public struct PRECTF
        {
            float left;
            float top;
            float right;
            float bottom;
        };
        public struct LPRECTF
        {
            float left;
            float top;
            float right;
            float bottom;
        };

        public struct tagPOINTF
        {
            float x;
            float y;
        };

        public struct POINTF
        {
            float x;
            float y;
        };

        public struct PPOINTF
        {
            float x;
            float y;
        };

        public struct LPPOINTF
        {
            float x;
            float y;
        };

        public struct tagSIZEF
        {
            float cx;
            float cy;
        };
        public struct SIZEF
        {
            float cx;
            float cy;
        };
        public struct PSIZEF
        {
            float cx;
            float cy;
        };
        public struct LPSIZEF
        {
            float cx;
            float cy;
        };

        // double 
        public struct tagRECTD
        {
            double left;
            double top;
            double right;
            double bottom;
        };
        public struct RECTD
        {
            double left;
            double top;
            double right;
            double bottom;
        };
        public struct PRECTD
        {
            double left;
            double top;
            double right;
            double bottom;
        };
        public struct LPRECTD
        {
            double left;
            double top;
            double right;
            double bottom;
        };

        public struct Point
        {
            double x;
            double y;
        };
        public struct Point
        {
            double x;
            double y;
        };
        public struct tagPOINTD
        {
            double x;
            double y;
        };
        public struct POINTD
        {
            double x;
            double y;
        };
        public struct PPOINTD
        {
            double x;
            double y;
        };
        public struct LPPOINTD
        {
            double x;
            double y;
        };

        public struct CSize
        {
            double cx;
            double cy;
        };
        public struct tagSIZED
        {
            double cx;
            double cy;
        };
        public struct SIZED
        {
            double cx;
            double cy;
        };
        public struct PSIZED
        {
            double cx;
            double cy;
        };
        public struct LPSIZED
        {
            double cx;
            double cy;
        };
    }
    public class CWhPointD : CWhVirtual
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhPointD()
        {
            m_fx = 0.0;
            m_fy = 0.0;
        }
        public CWhPointD(ref CWhPointD point)
        {
            m_fx = point.m_fx;
            m_fy = point.m_fy;
        }
        public CWhPointD(double x, double y)
        {
            m_fx = x;
            m_fy = y;
        }
        public CWhPointD(Point point)
        {
            m_fx = point.X;
            m_fy = point.Y;
        }
        public double m_fx;
        public double m_fy;        
        public void CopyFrom(CWhPointD point)
        {
            m_fx = point.m_fx;
            m_fy = point.m_fy;
        }        
        public static CWhPointD operator +(CWhPointD ImpliedObject, CWhPointD point)
        {
            CWhPointD ptRet = new CWhPointD();

            return ptRet;
        }
        public static CWhPointD operator -(CWhPointD ImpliedObject, CWhPointD point)
        {
            CWhPointD ptRet = new CWhPointD();

            return ptRet;
        }

        public double Distance(ref CWhPointD ptInput)
        {
            double fRet = 0.0;

            fRet = (m_fx - ptInput.m_fx) * (m_fx - ptInput.m_fx) + (m_fy - ptInput.m_fy) * (m_fy - ptInput.m_fy);
            fRet = System.Math.Sqrt(fRet);

            return fRet;
        }
    }
    public class CWhRectD : CWhVirtual
    {
        public CWhPointD m_ptdTopLeft = new CWhPointD();
        public CWhPointD m_ptdBtmRight = new CWhPointD();        
    }
    public class CWhLine : CWhVirtual
    {
        public CWhLine(Point ptStart, Point ptEnd)
        {
            m_ptStart = ptStart;
            m_ptEnd = ptEnd;
            m_nObjType = DefineConstantsFdxf.WH_TYPE_LINE;
            SetObjDefaultProperty();
            UpdateBoundRect();
        }
        public Point m_ptStart = new Point();
        public Point m_ptEnd = new Point();

        public void Serialize(ref BinaryFormatter ar)
        {
            CWhVirtual.Serialize(ar);
            if (ar.IsStoring() != 0)
            {
                ar << m_ptStart << m_ptEnd;
            }
            else
            {
                ar >> m_ptStart >> m_ptEnd;
            }
        }
        public new void UpdateBoundRect()
        {
            m_rcBound.SetRect(m_ptStart, m_ptEnd);
            m_rcBound.NormalizeRect();
            if (m_rcBound.IsRectEmpty())
            {
                m_rcBound.InflateRect(m_rcBound.Width() ? 0 : 1, m_rcBound.Height() ? 0 : 1);
            }
        }
        public void Draw(ref Graphics pDC, Rectangle rcClient)
        {

            if (m_bIsShow)
            {

                Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);
                Rectangle rcClientReal = TransDPtoRP(rcClient, pDC);
                if (!rcInterSectRect.IntersectRect(m_rcBound, rcClientReal))
                {
                    return;
                }

                Point ptStart = new Point();
                Point ptEnd = new Point();

                ptStart = TransRPtoLP(m_ptStart);
                ptEnd = TransRPtoLP(m_ptEnd);

                CPen pOldPen = null;
                CPen penLine = new CPen();
                penLine.CreatePen(PS_SOLID, m_nPenWidth, m_colPenColor);
                pOldPen = pDC.SelectObject(penLine);

                pDC.MoveTo(ptStart);
                pDC.LineTo(ptEnd);
                pDC.SelectObject(pOldPen);

                if (m_bIsShowHandle)
                {
                    DrawHandle(ref pDC);
                }
            }
        }
        public void DrawHandle(ref Graphics pDC)
        {
            Point ptStart = new Point();
            Point ptEnd = new Point();

            ptStart = TransRPtoLP(m_ptStart);
            ptEnd = TransRPtoLP(m_ptEnd);

            Rectangle rcHandle = new Rectangle(0, 0, 2, 2);
            pDC.DPtoLP(rcHandle);
            Rectangle rcStart = new Rectangle(ptStart.x, ptStart.y, ptStart.x, ptStart.y);
            Rectangle rcEnd = new Rectangle(ptEnd.x, ptEnd.y, ptEnd.x, ptEnd.y);

            rcStart.InflateRect(rcHandle.Width(), rcHandle.Height());
            rcEnd.InflateRect(rcHandle.Width(), rcHandle.Height());


            //设置画笔
            CPen pOldPen = null;
            CPen pen = new CPen();
            pen.CreatePen(PS_SOLID, rcHandle.Width()  ,2, RGB(0, 0, 255));
            pOldPen = pDC.SelectObject(pen);
            //pDC->Rectangle(rcStart);
            pDC.Rectangle(rcEnd);
            //还原画笔
            pDC.SelectObject(pOldPen);

            //设置画笔
            CPen pOldPen1 = null;
            CPen pen1 = new CPen();
            pen1.CreatePen(PS_SOLID, rcHandle.Width()  ,2, RGB(255, 0, 0));
            pOldPen1 = pDC.SelectObject(pen1);
            pDC.Rectangle(rcStart);
            //还原画笔
            pDC.SelectObject(pOldPen1);
        }
        public void DrawArrow(ref Graphics pDC)
        {

        }
        public void DrawStartPoint(ref Graphics pDC)
        {
            Point ptStart = new Point();

            ptStart = TransRPtoLP(m_ptStart);

            Rectangle rcHandle = new Rectangle(0, 0, 3, 3);
            pDC.DPtoLP(rcHandle);
            Rectangle rcStart = new Rectangle(ptStart.x, ptStart.y, ptStart.x, ptStart.y);
            rcStart.InflateRect(rcHandle.Width(), rcHandle.Height());


            CBrush pOldBrush = null;
            IntPtr hGdi = GetStockObject(NULL_BRUSH);
            CBrush pBrush = CBrush.FromHandle((IntPtr)hGdi);
            pOldBrush = pDC.SelectObject(pBrush);
            CPen pOldPen = null;
            CPen pen = new CPen();
            pen.CreatePen(PS_SOLID, 0, RGB(255, 0, 0));
            pOldPen = pDC.SelectObject(pen);
            pDC.Rectangle(rcStart);

            pDC.SelectObject(pOldPen);
            pDC.SelectObject(pOldBrush);
        }
        public new int IsValid()
        {
            if (m_ptStart == m_ptEnd)
            {
                return false;
            }
            return true;
        }
        public new void Move(int nX, int nY)
        {
            Point ptMove = new Point(nX, nY);
            m_ptStart += ptMove;
            m_ptEnd += ptMove;
            UpdateBoundRect();
        }
        public new void ExchangeStartToEnd()
        {
            Point ptTem = new Point(0, 0);
            ptTem = m_ptStart;
            SetStartPoint(m_ptEnd);
            SetEndPoint(ptTem);
            UpdateBoundRect();
        }
        public void DrawNumber(ref Graphics pDC)
        {
            string strNum;
            strNum.Format("%d", m_lID);
            Point pt = TransRPtoLP(m_ptStart);
            pDC.TextOut(pt.x, pt.y, strNum);
        }

        public new int IsSelected(Point ptClick, int nLimit)
        {
            int bRet = false;

            Rectangle rcBound = new Rectangle(m_rcBound);
            rcBound.InflateRect(nLimit, nLimit); //wuhao

            if (rcBound.PtInRect(ptClick))
            {

                int nDisTance = GlobalMembersWhLine.PointToLineDistance(m_ptStart, m_ptEnd, ptClick);
                if (nDisTance <= nLimit)
                {
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }
        public new int IsSelected(Rectangle rcClick, int bFlagMode)
        {
            int bRet = false;

            Rectangle rcBound = new Rectangle(m_rcBound);
            Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);
            rcBound.InflateRect(1, 1);

            if (bFlagMode == -1)
            {
                if (rcInterSectRect.IntersectRect(m_rcBound, rcClick))
                {
                    bRet = true;
                    return bRet;
                }
            }
            else if (bFlagMode == 1)
            {
                rcInterSectRect.IntersectRect(m_rcBound, rcClick);
                if (rcInterSectRect == m_rcBound)
                {
                    bRet = true;
                    return bRet;
                }
            }

            return bRet;
        }
        public int IsPointSnap(ref Point ptSnap, Point ptInput, double fDiatance)
        {
            int bRet = false;
            Rectangle rcSnap = m_rcBound;
            rcSnap.InflateRect(2 * (int)fDiatance, 2 * (int)fDiatance);


            if (!rcSnap.PtInRect(ptInput))
            {
                return false;
            }

            Rectangle[] rc = new Rectangle[3];
            rc[0] = Rectangle(m_ptStart, m_ptStart);
            rc[1] = Rectangle(m_ptEnd, m_ptEnd);
            rc[2] = Rectangle(Point((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0)), Point((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0)));

            for (int i = 0; i < 3; i++)
            {
                rc[i].InflateRect((int)fDiatance, (int)fDiatance);
            }

            if (rc[0].PtInRect(ptInput))
            {
                ptSnap = m_ptStart;
                bRet = true;
                return bRet;
            }
            else if (rc[1].PtInRect(ptInput))
            {
                ptSnap = m_ptEnd;
                bRet = true;
                return bRet;
            }
            else if (rc[2].PtInRect(ptInput))
            {
                ptSnap = Point((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0));
                bRet = true;
                return bRet;
            }

            return bRet;
        }
        public int IsPointSelect(ref Point ptSnap, ref int nSnap, Point ptInput, double fDiatance)
        {
            int bRet = false;

            Rectangle rcSnap = m_rcBound;
            rcSnap.InflateRect((int)fDiatance, (int)fDiatance);
            if (!rcSnap.PtInRect(ptInput))
            {
                return bRet;
            }


            Rectangle[] rc = new Rectangle[3];
            rc[0] = Rectangle(m_ptStart, m_ptStart);
            rc[1] = Rectangle(m_ptEnd, m_ptEnd);
            rc[2] = Rectangle(Point((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0)), Point((int)((m_ptStart.x + m_ptEnd.x) / 2.0), (int)((m_ptStart.y + m_ptEnd.y) / 2.0)));

            for (int i = 0; i < 3; i++)
            {
                rc[i].InflateRect((int)fDiatance, (int)fDiatance);
            }


            if (rc[0].PtInRect(ptInput))
            {
                ptSnap = m_ptStart;
                nSnap = 1;
                bRet = true;
                return bRet;
            }
            else if (rc[1].PtInRect(ptInput))
            {
                ptSnap = m_ptEnd;
                nSnap = 2;
                bRet = true;
                return bRet;
            }
            else if (rc[2].PtInRect(ptInput))
            {
                return bRet;
            }

            return bRet;
        }
        public int IsStartPointSelect(ref Point ptRet, Point ptInput, double fDiatance)
        {
            int bRet = false;
            Rectangle rcSnap = m_rcBound;
            rcSnap.InflateRect(2 * (int)fDiatance, 2 * (int)fDiatance);

            if (!rcSnap.PtInRect(ptInput))
            {
                return false;
            }

            Rectangle rcStart = new Rectangle();
            rcStart = Rectangle(m_ptStart, m_ptStart);
            rcStart.InflateRect((int)fDiatance, (int)fDiatance);
            if (rcStart.PtInRect(ptInput))
            {
                ptRet = m_ptStart;
                bRet = true;
                return bRet;
            }
            return bRet;
        }

        public void SetStartPoint(Point ptStart)
        {
            m_ptStart = ptStart;
            UpdateBoundRect();
        }
        public void SetEndPoint(Point ptEnd)
        {
            m_ptEnd = ptEnd;
            UpdateBoundRect();
        }
        public void SetStartPoint(int x, int y)
        {
            m_ptStart.x = x;
            m_ptStart.y = y;
            UpdateBoundRect();
        }
        public void SetEndPoint(int x, int y)
        {
            m_ptEnd.x = x;
            m_ptEnd.y = y;
            UpdateBoundRect();
        }
        public new Point GetStartPoint()
        {
            return m_ptStart;
        }
        public new Point GetEndPoint()
        {
            return m_ptEnd;
        }
        public new int IsObjValid()
        {
            if (m_ptStart == m_ptEnd)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public new void SetObjDefaultProperty()
        {
            m_colPenColor = RGB(0, 0, 0);
        }
    }
    public class CWhLayer : CWhVirtual
    {
        public void Serialize(ref BinaryFormatter ar)
        {
            CWhVirtual.Serialize(ar);
            m_pListLayer.Serialize(ref ar);
            if (ar.IsLoading() != 0)
            {
                ar >> m_strLayerName;
            }
            else
            {
                ar << m_strLayerName;
            }
        }
        public new void UpdateBoundRect()
        {
            m_pListLayer.UpdateBoundRect();
            m_rcBound = m_pListLayer.m_rcBound;
        }
        public new void Move(int nX, int nY)
        {
            CWhVirtual pObj = null;
            if (m_pListLayer.IsEmpty() == 0)
            {
                __POSITION pos = m_pListLayer.GetHeadPosition();
                while (pos != null)
                {
                    pObj = m_pListLayer.GetNext(ref pos);

                    pObj.Move(nX, nY);
                }
            }
            UpdateBoundRect();
        }
        public void DrawHandle(ref Graphics pDC)
        {
            Rectangle rcHandle = new Rectangle(0, 0, 2, 2);
            pDC.DPtoLP(rcHandle);
            Rectangle rcBoundLog = TransRPtoLP(m_rcBound);
            Rectangle[] rcHandPoint = new Rectangle[5];

            rcHandPoint[0].SetRect(rcBoundLog.Left, rcBoundLog.Top, rcBoundLog.Left, rcBoundLog.top);
            rcHandPoint[1].SetRect(rcBoundLog.Right, rcBoundLog.Top, rcBoundLog.Right, rcBoundLog.top);
            rcHandPoint[2].SetRect(rcBoundLog.Right, rcBoundLog.bottom, rcBoundLog.Right, rcBoundLog.Bottom);
            rcHandPoint[3].SetRect(rcBoundLog.Left, rcBoundLog.bottom, rcBoundLog.Left, rcBoundLog.Bottom);
            rcHandPoint[4].SetRect(rcBoundLog.CenterPoint().x, rcBoundLog.CenterPoint().y, rcBoundLog.CenterPoint().x, rcBoundLog.CenterPoint().y);
            for (int i = 0; i < 5; i++)
            {
                rcHandPoint[i].InflateRect(rcHandle.Width(), rcHandle.Height());
            }

            CPen pOldPen = null;
            CPen pen = new CPen();
            pen.CreatePen(PS_SOLID, rcHandle.Width()  ,2, RGB(255, 0, 0));
            pOldPen = pDC.SelectObject(pen);

            for (int j = 0; j < 5; j++)
            {
                pDC.Rectangle(rcHandPoint[j]);
            }
            pDC.SelectObject(pOldPen);
        }
        public void DrawArrow(ref Graphics pDC)
        {

        }
        public void DrawStartPoint(ref Graphics pDC)
        {
            CWhVirtual pObj = null;
            __POSITION pos = m_pListLayer.GetHeadPosition();
            while (pos != null)
            {
                pObj = m_pListLayer.GetNext(ref pos);
                pObj.DrawStartPoint(ref pDC);
            }
        }
        public void Draw(ref Graphics pDC, Rectangle rcClient)
        {
            if (m_bIsShow)
            {

                Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);
                Rectangle rcClientReal = TransDPtoRP(rcClient, pDC);
                if (!rcInterSectRect.IntersectRect(m_rcBound, rcClientReal))
                {
                    return;
                }


                CWhVirtual pObj = null;
                __POSITION pos = m_pListLayer.GetHeadPosition();
                while (pos != null)
                {
                    pObj = m_pListLayer.GetNext(ref pos);
                    pObj.Draw(ref pDC, rcClient);
                }


                if (m_bIsShowHandle)
                {
                    DrawHandle(ref pDC);
                }
            }
        }
        public void DrawNumber(ref Graphics pDC)
        {
            CWhVirtual pObj = null;
            __POSITION pos = m_pListLayer.GetHeadPosition();
            while (pos != null)
            {
                pObj = m_pListLayer.GetNext(ref pos);
                pObj.DrawNumber(ref pDC);
            }
        }
        public new Point GetStartPoint()
        {
            Point ptRet = new Point(0, 0);
            CWhVirtual pObj = m_pListLayer.GetHead();
            ptRet = pObj.GetStartPoint();
            return ptRet;
        }
        public new Point GetEndPoint()
        {
            Point ptRet = new Point(0, 0);
            CWhVirtual pObj = m_pListLayer.GetTail();
            ptRet = pObj.GetEndPoint();
            return ptRet;
        }

        public new void SetPenColor(uint colRef)
        {
            CWhVirtual pObj = null;
            __POSITION posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetPenColor(colRef);
            }
        }
        public new void SetObjDefaultProperty()
        {
            CWhVirtual pObj = null;
            __POSITION posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetObjDefaultProperty();
            }
        }
        public new void SetMachineCount(int nMachineCount)
        {

            m_nMachineCount = nMachineCount;

            CWhVirtual pObj = null;
            __POSITION posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetMachineCount(nMachineCount);
            }
        }
        public new void SetMachineFrequence(int nMachineFrequence)
        {

            m_nMachineFrequence = nMachineFrequence;

            CWhVirtual pObj = null;
            __POSITION posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetMachineCount(nMachineFrequence);
            }
        }
        public new void SetMachineStyle(int bMachineStyle)
        {

            m_bMachineStyle = bMachineStyle;

            CWhVirtual pObj = null;
            __POSITION posObj = m_pListLayer.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListLayer.GetNext(ref posObj);
                pObj.SetMachineStyle(bMachineStyle);
            }
        }

        public new int IsSelected(Point ptClick, int nLimit)
        {
            int bRet = DefineConstantsWhLayer.FALSE;

            Rectangle rcBound = new Rectangle(m_rcBound);
            rcBound.InflateRect(nLimit, nLimit);
            if (m_pListLayer.IsEmpty() == 0)
            {
                if (rcBound.PtInRect(ptClick))
                {
                    bRet = DefineConstantsWhLayer.TRUE;
                    return bRet;
                }
            }

            return bRet;
        }
        public new int IsSelected(Rectangle rcClick, int bFlagMode)
        {
            int bRet = DefineConstantsWhLayer.FALSE;

            if (m_pListLayer.IsEmpty() != 0)
            {
                return bRet;
            }

            Rectangle rcBound = new Rectangle(m_rcBound);
            Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);

            if (rcInterSectRect.IntersectRect(m_rcBound, rcClick))
            {
                bRet = DefineConstantsWhLayer.TRUE;
                return bRet;
            }

            return bRet;
        }
        public int IsPointSnap(ref Point ptSnap, Point ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhLayer.FALSE;
            if (m_rcBound.PtInRect(ptInput))
            {
                bRet = DefineConstantsWhLayer.TRUE;
                return bRet;
            }
            return bRet;
        }
        public int IsStartPointSelect(ref Point ptRet, Point ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhLayer.FALSE;
            return bRet;
        }

        public CWhListContainer GetListLayer()
        {
            return m_pListLayer;
        }
        public int FindObject(CWhVirtual pObj)
        {
            return m_pListLayer.FindObject(pObj);
        }
        public CWhVirtual FindObjectFromID(int lID)
        {
            return m_pListLayer.FindObjectFromID(lID);
        }
        public void MoveObjNext(CWhVirtual pObj)
        {
            m_pListLayer.MoveObjNext(pObj);
        }
        public void MoveObjPrev(CWhVirtual pObj)
        {
            m_pListLayer.MoveObjPrev(pObj);
        }

        public void AddObject(CWhVirtual pObj)
        {
            m_pListLayer.AddObject(pObj);
            m_rcBound = m_pListLayer.m_rcBound;
        }
        public void AddObjects(CWhListContainer pListObj)
        {
            m_pListLayer.AddObjects(pListObj);
            m_rcBound = m_pListLayer.m_rcBound;
        }

        public int RemoveObject(CWhVirtual pObj)
        {
            return RemoveObject(pObj, DefineConstantsWhLayer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: int RemoveObject(CWhVirtual pObj, int bFlagDepth = DefineConstantsWhLayer.FALSE)
        public int RemoveObject(CWhVirtual pObj, int bFlagDepth)
        {
            return m_pListLayer.RemoveObject(pObj, bFlagDepth);
        }
        public void RemoveObjects(CWhListContainer pListObj)
        {
            RemoveObjects(pListObj, DefineConstantsWhLayer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void RemoveObjects(CWhListContainer pListObj, int bFlagDepth = DefineConstantsWhLayer.FALSE)
        public void RemoveObjects(CWhListContainer pListObj, int bFlagDepth)
        {
            m_pListLayer.RemoveObjects(pListObj, bFlagDepth);
        }
        public void RemoveAll()
        {
            RemoveAll(DefineConstantsWhLayer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void RemoveAll(int bFlagDepth = DefineConstantsWhLayer.FALSE)
        public void RemoveAll(int bFlagDepth)
        {
            m_pListLayer.RemoveAll(bFlagDepth);
        }
        public void DeleteObject(CWhVirtual pObj)
        {
            DeleteObject(pObj, DefineConstantsWhLayer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteObject(CWhVirtual pObj, int bFlagDepth = DefineConstantsWhLayer.FALSE)
        public void DeleteObject(CWhVirtual pObj, int bFlagDepth)
        {
            m_pListLayer.DeleteObject(pObj, bFlagDepth);
        }
        public void DeleteObjects(CWhListContainer pListObj)
        {
            DeleteObjects(pListObj, DefineConstantsWhLayer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteObjects(CWhListContainer pListObj, int bFlagDepth = DefineConstantsWhLayer.FALSE)
        public void DeleteObjects(CWhListContainer pListObj, int bFlagDepth)
        {
            m_pListLayer.DeleteObjects(pListObj, bFlagDepth);
        }
        public void DeleteAll()
        {
            DeleteAll(DefineConstantsWhLayer.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteAll(int bFlagDepth = DefineConstantsWhLayer.FALSE)
        public void DeleteAll(int bFlagDepth)
        {
            m_pListLayer.DeleteAll(bFlagDepth);
        }

        public void SetLayerName(string strLayerName)
        {
            m_strLayerName = strLayerName;
        }
        public string GetLayerName()
        {
            return m_strLayerName;
        }

        public CWhListContainer m_pListLayer;
        public string m_strLayerName;
    }
    public class CWhGroup : CWhVirtual
    {
        
        public void Serialize(ref BinaryFormatter ar)
        {
            CWhVirtual.Serialize(ar);
            m_pListGroup.Serialize(ref ar);
            if (ar.IsStoring() != 0)
            {
                ar << m_rcGridBound;
            }
            else
            {
                ar >> m_rcGridBound;
            }
        }
        public new void UpdateBoundRect()
        {
            m_pListGroup.UpdateBoundRect();
            m_rcBound = m_pListGroup.m_rcBound;
        }
        public new void Move(int nX, int nY)
        {
            CWhVirtual pObj = null;
            if (m_pListGroup.IsEmpty() == 0)
            {
                __POSITION pos = m_pListGroup.GetHeadPosition();
                while (pos != null)
                {
                    pObj = m_pListGroup.GetNext(ref pos);

                    pObj.Move(nX, nY);
                }
            }
            UpdateBoundRect();
        }
        public void DrawHandle(ref Graphics pDC)
        {
            CWhVirtual pObjFirst = m_pListGroup.GetHead();
            CWhVirtual pObjEnd = m_pListGroup.GetTail();

            Point ptStart = new Point();
            Point ptEnd = new Point();

            ptStart = TransRPtoLP(pObjFirst.GetStartPoint());
            ptEnd = TransRPtoLP(pObjEnd.GetEndPoint());

            Rectangle rcHandle = new Rectangle(0, 0, 2, 2);
            pDC.DPtoLP(rcHandle);
            Rectangle rcStart = new Rectangle(ptStart.x, ptStart.y, ptStart.x, ptStart.y);
            Rectangle rcEnd = new Rectangle(ptEnd.x, ptEnd.y, ptEnd.x, ptEnd.y);
            rcStart.InflateRect(rcHandle.Width(), rcHandle.Height());
            rcEnd.InflateRect(rcHandle.Width(), rcHandle.Height());


            CPen pOldPen = null;
            CPen pen = new CPen();
            pen.CreatePen(PS_SOLID, rcHandle.Width()  ,2, RGB(0, 0, 255));
            pOldPen = pDC.SelectObject(pen);
            pDC.Rectangle(rcEnd);

            pDC.SelectObject(pOldPen);


            CPen pOldPen1 = null;
            CPen pen1 = new CPen();
            pen1.CreatePen(PS_SOLID, rcHandle.Width()  ,2, RGB(255, 0, 0));
            pOldPen1 = pDC.SelectObject(pen1);
            pDC.Rectangle(rcStart);

            pDC.SelectObject(pOldPen1);
        }
        public void DrawArrow(ref Graphics pDC)
        {

        }
        public void DrawStartPoint(ref Graphics pDC)
        {
            CWhVirtual pObjStart = m_pListGroup.GetHead();
            if (pObjStart != null)
            {
                pObjStart.DrawStartPoint(ref pDC);
            }
        }
        public void DrawNumber(ref Graphics pDC)
        {
            CWhVirtual pObjFirst = m_pListGroup.GetHead();
            string strNum;
            strNum.Format("%d", m_lID);
            Point pt = TransRPtoLP(pObjFirst.GetStartPoint());
            pDC.TextOut(pt.x, pt.y, strNum);
        }
        public void Draw(ref Graphics pDC, Rectangle rcClient)
        {
            if (m_bIsShow)
            {

                Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);
                Rectangle rcClientReal = TransDPtoRP(rcClient, pDC);
                if (!rcInterSectRect.IntersectRect(m_rcBound, rcClientReal))
                {
                    return;
                }

                CWhVirtual pObj = null;
                __POSITION pos = m_pListGroup.GetHeadPosition();
                while (pos != null)
                {
                    pObj = m_pListGroup.GetNext(ref pos);
                    pObj.Draw(ref pDC, rcClient);
                }


                if (m_bIsShowHandle)
                {
                    DrawHandle(ref pDC);
                }
            }
        }
        public new void ExchangeStartToEnd()
        {

            CWhVirtual pObj = null;
            __POSITION posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.ExchangeStartToEnd();
            }

            m_pListGroup.AntiList();
        }
        public new Point GetStartPoint()
        {
            Point ptRet = new Point(0, 0);
            CWhVirtual pObj = m_pListGroup.GetHead();
            ptRet = pObj.GetStartPoint();
            return ptRet;
        }
        public new Point GetEndPoint()
        {
            Point ptRet = new Point(0, 0);
            CWhVirtual pObj = m_pListGroup.GetTail();
            ptRet = pObj.GetEndPoint();
            return ptRet;
        }

        public new void SetPenColor(uint colRef)
        {
            CWhVirtual pObj = null;
            __POSITION posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetPenColor(colRef);
            }
        }
        public new void SetObjDefaultProperty()
        {
            CWhVirtual pObj = null;
            __POSITION posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetObjDefaultProperty();
            }
        }
        public new void SetMachineCount(int nMachineCount)
        {

            m_nMachineCount = nMachineCount;

            CWhVirtual pObj = null;
            __POSITION posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetMachineCount(nMachineCount);
            }
        }
        public new void SetMachineFrequence(int nMachineFrequence)
        {

            m_nMachineFrequence = nMachineFrequence;

            CWhVirtual pObj = null;
            __POSITION posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetMachineCount(nMachineFrequence);
            }
        }
        public new void SetMachineStyle(int bMachineStyle)
        {

            m_bMachineStyle = bMachineStyle;

            CWhVirtual pObj = null;
            __POSITION posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                pObj.SetMachineStyle(bMachineStyle);
            }
        }

        public new int IsSelected(Point ptClick, int nLimit)
        {
            int bRet = DefineConstantsWhGroup.FALSE;
            if (m_pListGroup.IsEmpty() == 0)
            {

                Rectangle rcBound = new Rectangle(m_rcBound);
                rcBound.InflateRect(nLimit, nLimit);

                if (rcBound.PtInRect(ptClick))
                {

                    CWhVirtual pObjSelect = null;
                    __POSITION posSelect = m_pListGroup.GetHeadPosition();
                    while (posSelect != null)
                    {
                        pObjSelect = m_pListGroup.GetNext(ref posSelect);

                        if (pObjSelect.IsSelected(ptClick, nLimit) != 0)
                        {
                            bRet = DefineConstantsWhGroup.TRUE;
                            return bRet;
                        }
                    }
                }
            }

            return bRet;
        }
        public new int IsSelected(Rectangle rcClick, int bFlagMode)
        {
            int bRet = DefineConstantsWhGroup.FALSE;
            Rectangle rcBound = new Rectangle(m_rcBound);
            Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);

            if (bFlagMode == -1)
            {
                if (rcInterSectRect.IntersectRect(m_rcBound, rcClick))
                {
                    CWhVirtual pObjSelect = null;
                    __POSITION posSelect = m_pListGroup.GetHeadPosition();
                    while (posSelect != null)
                    {
                        pObjSelect = m_pListGroup.GetNext(ref posSelect);

                        if (pObjSelect.IsSelected(rcClick, bFlagMode) != 0)
                        {
                            bRet = DefineConstantsWhGroup.TRUE;
                            return bRet;
                        }
                    }
                }
            }
            else if (bFlagMode == 1)
            {
                rcInterSectRect.IntersectRect(m_rcBound, rcClick);
                if (rcInterSectRect == m_rcBound)
                {
                    bRet = DefineConstantsWhGroup.TRUE;
                    return bRet;
                }
            }

            return bRet;
        }
        public int IsPointSnap(ref Point ptSnap, Point ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhGroup.FALSE;
            if (m_rcBound.PtInRect(ptInput))
            {
                bRet = DefineConstantsWhGroup.TRUE;
                return bRet;
            }
            return bRet;
        }
        public int IsStartPointSelect(ref Point ptRet, Point ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhGroup.FALSE;
            Rectangle rcSnap = m_rcBound;
            rcSnap.InflateRect(2 * (int)fDiatance, 2 * (int)fDiatance);

            if (!rcSnap.PtInRect(ptInput))
            {
                return DefineConstantsWhGroup.FALSE;
            }

            CWhVirtual pObj = null;
            __POSITION posObj = m_pListGroup.GetHeadPosition();
            pObj = m_pListGroup.GetNext(ref posObj);
            if (pObj.IsStartPointSelect(ref ptRet, ptInput, fDiatance) != 0)
            {
                bRet = DefineConstantsWhGroup.TRUE;
                return bRet;
            }
            return bRet;
        }

        public int FindObject(CWhVirtual pObj)
        {
            return m_pListGroup.FindObject(pObj);
        }
        public CWhListContainer GetListGroup()
        {
            return m_pListGroup;
        }

        public void AddObject(CWhVirtual pObj)
        {
            m_pListGroup.AddObject(pObj);
            m_rcBound = m_pListGroup.m_rcBound;
        }
        public void AddObjects(CWhListContainer pListObj)
        {
            m_pListGroup.AddObjects(pListObj);
            m_rcBound = m_pListGroup.m_rcBound;
        }

        public int RemoveObject(CWhVirtual pObj)
        {
            return RemoveObject(pObj, DefineConstantsWhGroup.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: int RemoveObject(CWhVirtual pObj, int bFlagDepth = DefineConstantsWhGroup.FALSE)
        public int RemoveObject(CWhVirtual pObj, int bFlagDepth)
        {
            return m_pListGroup.RemoveObject(pObj, bFlagDepth);
        }
        public void RemoveObjects(CWhListContainer pListObj)
        {
            RemoveObjects(pListObj, DefineConstantsWhGroup.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void RemoveObjects(CWhListContainer pListObj, int bFlagDepth = DefineConstantsWhGroup.FALSE)
        public void RemoveObjects(CWhListContainer pListObj, int bFlagDepth)
        {
            m_pListGroup.RemoveObjects(pListObj, bFlagDepth);
        }
        public void RemoveAll()
        {
            RemoveAll(DefineConstantsWhGroup.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void RemoveAll(int bFlagDepth = DefineConstantsWhGroup.FALSE)
        public void RemoveAll(int bFlagDepth)
        {
            m_pListGroup.RemoveAll(bFlagDepth);
        }
        public void DeleteObject(CWhVirtual pObj)
        {
            DeleteObject(pObj, DefineConstantsWhGroup.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteObject(CWhVirtual pObj, int bFlagDepth = DefineConstantsWhGroup.FALSE)
        public void DeleteObject(CWhVirtual pObj, int bFlagDepth)
        {
            m_pListGroup.DeleteObject(pObj, bFlagDepth);
        }
        public void DeleteObjects(CWhListContainer pListObj)
        {
            DeleteObjects(pListObj, DefineConstantsWhGroup.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteObjects(CWhListContainer pListObj, int bFlagDepth = DefineConstantsWhGroup.FALSE)
        public void DeleteObjects(CWhListContainer pListObj, int bFlagDepth)
        {
            m_pListGroup.DeleteObjects(pListObj, bFlagDepth);
        }
        public void DeleteAll()
        {
            DeleteAll(DefineConstantsWhGroup.FALSE);
        }
        //C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        //ORIGINAL LINE: void DeleteAll(int bFlagDepth = DefineConstantsWhGroup.FALSE)
        public void DeleteAll(int bFlagDepth)
        {
            m_pListGroup.DeleteAll(bFlagDepth);
        }

        public void ConnectHeadToEnd()
        {

        }
        public void Apart()
        {
            CWhVirtual pObj = null;
            __POSITION posObj = m_pListGroup.GetHeadPosition();
            while (posObj != null)
            {
                pObj = m_pListGroup.GetNext(ref posObj);
                m_pParentList.AddObject(pObj);

                pObj.m_pParentList = m_pParentList;
            }
        }

        public CWhListContainer m_pListGroup;
        public Rectangle m_rcGridBound = new Rectangle();
        public string m_strParentLayerName;
    }
    public class CWhEllipse : CWhVirtual
    { //圆和矩形,椭圆类
       
        public CWhEllipse(Rectangle rcEllipse, int nTypeObj)
        {
            m_nObjType = DefineConstantsFdxf.WH_TYPE_ELLIPSE;
            m_nEllipseType = nTypeObj;

            m_rcBound = rcEllipse;
            m_nRadium = (int)((m_rcBound.Width() + m_rcBound.Height()) / 4.0);
            SetObjDefaultProperty();
        }

        public int m_nRadium;
        public int m_nEllipseType;

        public void Serialize(ref BinaryFormatter ar)
        {
            GlobalMembersWhEllipse.CWhVirtual.Serialize(ar);

            if (ar.IsStoring() != 0)
            {
                ar << m_nEllipseType << m_nRadium;
            }
            else
            {
                ar >> m_nEllipseType >> m_nRadium;
            }
        }
        public new void UpdateBoundRect()
        {
            m_rcBound.NormalizeRect();
            m_nRadium = (int)((m_rcBound.Width() + m_rcBound.Height()) / 4.0);
        }
        public void Draw(ref Graphics pDC, Rectangle rcClient)
        {

            if (m_bIsShow)
            {

                Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);
                Rectangle rcClientReal = TransDPtoRP(rcClient, pDC);
                if (!rcInterSectRect.IntersectRect(m_rcBound, rcClientReal))
                {
                    return;
                }


                Rectangle rcEllipse = new Rectangle();

                rcEllipse = TransRPtoLP(m_rcBound);


                CPen pOldPen = null;
                CPen penEllipse = new CPen();
                penEllipse.CreatePen(PS_SOLID, m_nPenWidth, m_colPenColor);
                pOldPen = pDC.SelectObject(penEllipse);


                CBrush pOldBrush = null;
                CBrush brushEllipse = new CBrush();
                if (m_bIsFilled)
                {

                    int bRet = brushEllipse.CreateSolidBrush(m_colBrush);
                    pOldBrush = pDC.SelectObject(brushEllipse);
                }
                else
                {
                    IntPtr hGdi = GetStockObject(NULL_BRUSH);
                    CBrush pBrush = CBrush.FromHandle((IntPtr)hGdi);
                    pOldBrush = pDC.SelectObject(pBrush);
                }


                if (m_nEllipseType == 0)
                {
                    pDC.Ellipse(rcEllipse);
                }
                else if (m_nEllipseType == 1)
                {
                    pDC.Rectangle(rcEllipse);
                }

                pDC.SelectObject(pOldPen);
                pDC.SelectObject(pOldBrush);


                if (m_bIsShowHandle)
                {
                    DrawHandle(ref pDC);
                }
            }
        }
        public void DrawHandle(ref Graphics pDC)
        {
            Rectangle rcBound = new Rectangle();

            rcBound = TransRPtoLP(m_rcBound);

            Rectangle rcHandle = new Rectangle(0, 0, 2, 2);
            pDC.DPtoLP(rcHandle);
            Rectangle rcBottom = new Rectangle((int)((rcBound.left + rcBound.right) / 2), rcBound.bottom, (int)((rcBound.left + rcBound.right) / 2), rcBound.Bottom);
            Rectangle rcCenter = new Rectangle(rcBound.CenterPoint(), rcBound.CenterPoint());
            rcBottom.InflateRect(rcHandle.Width(), rcHandle.Height());
            rcCenter.InflateRect(rcHandle.Width(), rcHandle.Height());
            //设置画笔
            CPen pOldPen = null;
            CPen pen = new CPen();
            pen.CreatePen(PS_SOLID, rcHandle.Width()  ,2, RGB(0, 0, 255));
            pOldPen = pDC.SelectObject(pen);
            pDC.Rectangle(rcCenter);
            //还原画笔
            pDC.SelectObject(pOldPen);

            //设置画笔
            CPen pOldPen1 = null;
            CPen pen1 = new CPen();
            pen1.CreatePen(PS_SOLID, rcHandle.Width()  ,2, RGB(255, 0, 0));
            pOldPen1 = pDC.SelectObject(pen1);
            pDC.Rectangle(rcBottom);
            //还原画笔
            pDC.SelectObject(pOldPen1);
        }
        public void DrawArrow(ref Graphics pDC)
        {

        }
        public void DrawStartPoint(ref Graphics pDC)
        {
            Point ptStart = new Point(0, 0);
            if (m_nEllipseType == 0)
            {
                ptStart = Point(m_rcBound.CenterPoint().x, m_rcBound.top);
            }
            else if (m_nEllipseType == 1)
            {
                ptStart = Point(m_rcBound.TopLeft());
            }

            ptStart = TransRPtoLP(ptStart);

            Rectangle rcHandle = new Rectangle(0, 0, 3, 3);
            pDC.DPtoLP(rcHandle);
            Rectangle rcStart = new Rectangle(ptStart.x, ptStart.y, ptStart.x, ptStart.y);
            rcStart.InflateRect(rcHandle.Width(), rcHandle.Height());

            //设置画笔
            CBrush pOldBrush = null;
            IntPtr hGdi = GetStockObject(NULL_BRUSH);
            CBrush pBrush = CBrush.FromHandle((IntPtr)hGdi);
            pOldBrush = pDC.SelectObject(pBrush);
            CPen pOldPen = null;
            CPen pen = new CPen();
            pen.CreatePen(PS_SOLID, 0, RGB(255, 0, 0));
            pOldPen = pDC.SelectObject(pen);
            pDC.Rectangle(rcStart);
            //还原画笔
            pDC.SelectObject(pOldPen);
            pDC.SelectObject(pOldBrush);
        }
        public void DrawNumber(ref Graphics pDC)
        {

            Point ptStart = new Point();
            if (m_nEllipseType == 0)
            {
                ptStart = Point(m_rcBound.CenterPoint().x, m_rcBound.top);
            }
            else if (m_nEllipseType == 1)
            {
                ptStart = Point(m_rcBound.TopLeft());
            }

            string strNum;
            strNum.Format("%d", m_lID);
            Point pt = TransRPtoLP(ptStart);
            pDC.TextOut(pt.x, pt.y, strNum);
        }
        public new int IsValid()
        {
            return DefineConstantsWhEllipse.TRUE;
        }
        public new void Move(int nX, int nY)
        {
            Point ptMove = new Point(nX, nY);
            m_rcBound.TopLeft() += ptMove;
            m_rcBound.BottomRight() += ptMove;
            UpdateBoundRect();
        }

        public int GetRadium()
        {
            return m_nRadium = (int)((m_rcBound.Width() + m_rcBound.Height()) / 4.0);
        }
        public void SetEllipseType(int nEllipseType)
        {
            m_nEllipseType = nEllipseType;
        }
        public int GetEllipseType()
        {
            return m_nEllipseType;
        }

        public new int IsSelected(Point ptClick, int nLimit)
        {
            int bRet = DefineConstantsWhEllipse.FALSE;
            int nDistance = 0;

            Rectangle rcBound = new Rectangle(m_rcBound);
            rcBound.InflateRect(nLimit, nLimit);

            if (rcBound.PtInRect(ptClick))
            {
                if (m_bIsFilled)
                {
                    bRet = DefineConstantsWhEllipse.TRUE;
                    return bRet;
                }

                if (m_nEllipseType == 0)
                {
                    nDistance = GlobalMembersWhEllipse.PointToPointDistance(m_rcBound.CenterPoint(), ptClick);
                    if ((nDistance <= m_nRadium + nLimit) && (nDistance) >= m_nRadium - nLimit)
                    {
                        bRet = DefineConstantsWhEllipse.TRUE;
                        return bRet;
                    }
                }
                else if (m_nEllipseType == 1)
                {

                    Rectangle rcOut = new Rectangle(m_rcBound);
                    Rectangle rcIn = new Rectangle(m_rcBound);
                    rcOut.InflateRect(nLimit, nLimit);
                    rcIn.DeflateRect(nLimit, nLimit);
                    if ((rcOut.PtInRect(ptClick)) && (!rcIn.PtInRect(ptClick)))
                    {
                        bRet = DefineConstantsWhEllipse.TRUE;
                        return bRet;
                    }
                }
            }

            return bRet;
        }
        public new int IsSelected(Rectangle rcClick, int bFlagMode)
        {
            int bRet = DefineConstantsWhEllipse.FALSE;
            Rectangle rcBound = new Rectangle(m_rcBound);
            Rectangle rcInterSectRect = new Rectangle(0, 0, 0, 0);

            if (bFlagMode == -1)
            {
                if (rcInterSectRect.IntersectRect(m_rcBound, rcClick))
                {
                    bRet = DefineConstantsWhEllipse.TRUE;
                    return bRet;
                }
            }
            else if (bFlagMode == 1)
            {
                rcInterSectRect.IntersectRect(m_rcBound, rcClick);
                if (rcInterSectRect == m_rcBound)
                {
                    bRet = DefineConstantsWhEllipse.TRUE;
                    return bRet;
                }
            }

            return bRet;
        }
        public int IsPointSnap(ref Point ptSnap, Point ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhEllipse.FALSE;
            Rectangle rcSnap = m_rcBound;
            rcSnap.InflateRect((int)fDiatance, (int)fDiatance);


            if (!rcSnap.PtInRect(ptInput))
            {
                return DefineConstantsWhEllipse.FALSE;
            }

            Rectangle[] rc = new Rectangle[5];
            rc[0] = Rectangle(m_rcBound.Left, (int)((m_rcBound.bottom + m_rcBound.top) / 2), m_rcBound.Left, (int)((m_rcBound.bottom + m_rcBound.top) / 2));
            rc[1] = Rectangle(m_rcBound.Right, (int)((m_rcBound.bottom + m_rcBound.top) / 2), m_rcBound.Right, (int)((m_rcBound.bottom + m_rcBound.top) / 2));
            rc[2] = Rectangle((int)((m_rcBound.bottom + m_rcBound.top) / 2), m_rcBound.Top, (int)((m_rcBound.bottom + m_rcBound.top) / 2), m_rcBound.top);
            rc[3] = Rectangle((int)((m_rcBound.bottom + m_rcBound.top) / 2), m_rcBound.bottom, (int)((m_rcBound.bottom + m_rcBound.top) / 2), m_rcBound.Bottom);
            rc[4] = Rectangle(m_rcBound.CenterPoint(), m_rcBound.CenterPoint());

            for (int i = 0; i < 5; i++)
            {
                rc[i].InflateRect((int)fDiatance, (int)fDiatance);
            }

            if (rc[0].PtInRect(ptInput))
            {
                ptSnap = Point(m_rcBound.Left, (int)((m_rcBound.bottom + m_rcBound.top) / 2));
                bRet = DefineConstantsWhEllipse.TRUE;
                return bRet;
            }
            else if (rc[1].PtInRect(ptInput))
            {
                ptSnap = Point(m_rcBound.Right, (int)((m_rcBound.bottom + m_rcBound.top) / 2));
                bRet = DefineConstantsWhEllipse.TRUE;
                return bRet;
            }
            else if (rc[2].PtInRect(ptInput))
            {
                ptSnap = Point((int)((m_rcBound.bottom + m_rcBound.top) / 2), m_rcBound.top);
                bRet = DefineConstantsWhEllipse.TRUE;
                return bRet;
            }
            else if (rc[3].PtInRect(ptInput))
            {
                ptSnap = Point((int)((m_rcBound.bottom + m_rcBound.top) / 2), m_rcBound.Bottom);
                bRet = DefineConstantsWhEllipse.TRUE;
                return bRet;
            }
            else if (rc[4].PtInRect(ptInput))
            {
                ptSnap = m_rcBound.CenterPoint();
                bRet = DefineConstantsWhEllipse.TRUE;
                return bRet;
            }

            return bRet;
        }
        public int IsStartPointSelect(ref Point ptRet, Point ptInput, double fDiatance)
        {
            int bRet = DefineConstantsWhEllipse.FALSE;
            Rectangle rcSnap = m_rcBound;
            rcSnap.InflateRect(2 * (int)fDiatance, 2 * (int)fDiatance);

            if (!rcSnap.PtInRect(ptInput))
            {
                return DefineConstantsWhEllipse.FALSE;
            }

            Rectangle rcStart = new Rectangle();
            if (m_nEllipseType == 0)
            {
                rcStart = Rectangle(Point(m_rcBound.CenterPoint().x, m_rcBound.top), Point(m_rcBound.CenterPoint().x, m_rcBound.top));
            }
            else if (m_nEllipseType == 1)
            {
                rcStart = Rectangle(Point(m_rcBound.TopLeft()), Point(m_rcBound.TopLeft()));
            }
            rcStart.InflateRect((int)fDiatance, (int)fDiatance);
            if (rcStart.PtInRect(ptInput))
            {
                ptRet = rcStart.CenterPoint();
                bRet = DefineConstantsWhEllipse.TRUE;
                return bRet;
            }
            return bRet;
        }

        public new void SetObjDefaultProperty()
        {
            m_colPenColor = RGB(0, 255, 0);
            if (!m_bFlagIsRegister)
            {
                m_colBrush = RGB(255, 0, 0); //默认的是红色刷子
            }
        }
    }
    public class CWhArc : CWhVirtual
    {   
        public Rectangle m_rcBoundDraw = new Rectangle();
        public Point m_ptStart = new Point();
        public Point m_ptEnd = new Point();
        public Point m_ptCenter = new Point();
        public int m_nRadium;
        public int m_nDirection;
        public int m_nGoodOrBad;
    }
    public class CWhDxfClass
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfClass()
        {

        }
        public virtual void Dispose()
        {

        }

    }
    public class tagUpPara
    {
        public Point centerPoint = new Point();
        public double fRadium;

        public tagUpPara()
        {
            centerPoint = new Point(0.0, 0.0);
            fRadium = 0.0;
        }

    }
    public class CWhDxfEntities
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfEntities()
        {
            m_pObjList = null;
            m_pCurrentLayer = null;
            m_nTypeEntities = 0;
            m_bFlagPolyLineStart = false;
            m_nLwPolyCount = 0;

            //临时对象初始化
            m_pTemGroup = null;
            m_pTemLine = null;
            m_pTemArc = null;
            m_pTemRect = null;


            m_fDxfRatio = 1.0;
            m_nDirection = 1;
            m_ptStart = new Point(0.0, 0.0);
            m_ptEnd = new Point(0.0, 0.0);
            m_ptCenter = new Point(0.0, 0.0);
            m_ptTem = new Point(0.0, 0.0);
            m_ptPre = new Point(0.0, 0.0);
            m_fRadium = 0.0;
            m_fAngleStart = 0.0;
            m_fAngleEnd = 0.0;
            m_fUpAngle = 0.0;
            m_nDxfCount = 0;
            m_nClosed = 0;
            m_fEllipseRatio = 1.0;
        }
        public virtual void Dispose()
        {
            m_pCurrentLayer = null;
            m_pTemGroup = null;
            m_pTemLine = null;
            m_pTemArc = null;
            m_pTemRect = null;
        }

        public void SetList(CWhListContainer pObjList)
        {
            m_pObjList = pObjList;
        }
        public void SetEntitiesString(ref tagDXFSTRING strInput)
        {
            m_strEntities.strCode = strInput.strCode;
            m_strEntities.strValue = strInput.strValue;
        }
        public int JustifyEntitiesType()
        {
            //C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
            //ORIGINAL LINE: string stringEntitiesName = m_strEntities.strCode;
            string stringEntitiesName = new @string(m_strEntities.strCode);
            //C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
            //ORIGINAL LINE: string stringEntitiesValue = m_strEntities.strValue;
            string stringEntitiesValue = new @string(m_strEntities.strValue);


            if (stringEntitiesName == "0")
            {
                //在下一图元开始前将当前图元加入链表
                AddObject();

                if (stringEntitiesValue == "LINE")
                {
                    m_nTypeEntities = 1;
                    return true;
                }
                else if (stringEntitiesValue == "ARC")
                {
                    m_nTypeEntities = 2;
                    return true;
                }
                else if (stringEntitiesValue == "CIRCLE")
                {
                    m_nTypeEntities = 3;
                    return true;
                }
                else if (stringEntitiesValue == "LWPOLYLINE")
                {
                    m_nTypeEntities = 4;
                    //m_bFlagPolyLineStart = TRUE;

                    //创建一个组并传给m_pTemGroup
                    m_pTemGroup = new CWhGroup();
                    return true;
                }
                else if (stringEntitiesValue == "POLYLINE")
                {
                    m_nTypeEntities = 5;
                    m_bFlagPolyLineStart = true;

                    //创建一个组并传给m_pTemGroup
                    m_pTemGroup = new CWhGroup();
                    return true;
                }
                else if (stringEntitiesValue == "SEQEND")
                {
                    m_nTypeEntities = 5;
                    m_bFlagPolyLineStart = false;
                    return true;
                }
                else if (stringEntitiesValue == "VERTEX")
                {
                    m_nTypeEntities = 6;
                    return true;
                }
                else if (stringEntitiesValue == "POINT")
                {
                    m_nTypeEntities = 7;
                    return true;
                }
                else if (stringEntitiesValue == "ELLIPSE")
                {
                    m_nTypeEntities = 8;
                    return true;
                }
                else
                {
                    m_nTypeEntities = 0;
                    return true;
                }


            }

            int ret = true;
            switch (m_nTypeEntities)
            {
                case 1:
                    ret = AnalyseLine(ref m_strEntities);

                    break;
                case 2:
                    ret = AnalyseArc(ref m_strEntities);

                    break;
                case 3:
                    ret = AnalyseCircle(ref m_strEntities);

                    break;
                case 4:
                    ret = AnalyseLwPolyLine(ref m_strEntities);

                    break;
                case 5:
                    ret = AnalysePolyLine(ref m_strEntities);

                    break;
                case 6:
                    ret = AnalyseVertex(ref m_strEntities);

                    break;
                case 7:
                    ret = AnalysePoint(ref m_strEntities);

                    break;
                case 8:
                    ret = AnalyseEllipse(ref m_strEntities);
                    break;
            }

            return ret;
        }
        public void ReSetPara()
        {
            m_ptStart = new Point(0.0, 0.0);
            m_ptEnd = new Point(0.0, 0.0);
            m_ptCenter = new Point(0.0, 0.0);
            m_fRadium = 0.0;
            m_nDirection = 1;
        }

        public bool AnalyseLine(ref tagDXFSTRING strEntities)
        {
            string stringLineName =strEntities.strCode;
            string stringLineValue = strEntities.strValue;

            if (stringLineName == "5" || stringLineName == "330" || stringLineName == "100") //handle ,ignore
            {
                return false;
            }
            else
            if (stringLineName == "8")
            {
                string strLayerName;
                strLayerName=stringLineValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringLineName == "10")
            {
                m_ptStart.x = float.Parse(stringLineValue);
                return true;
            }
            else if (stringLineName == "20")
            {
                m_ptStart.y = float.Parse(stringLineValue);
                return true;
            }
            else if (stringLineName == "11")
            {
                m_ptEnd.x = float.Parse(stringLineValue);
                return true;
            }
            else if (stringLineName == "21")
            {
                m_ptEnd.y = float.Parse(stringLineValue);
                return true;
            }
            return true;
        }
        public bool AnalyseArc(ref tagDXFSTRING strEntities)
        {
            string stringArcName = strEntities.strCode;
            string stringArcValue = strEntities.strValue;
            if (stringArcName == "5" || stringArcName == "330" || stringArcName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringArcName == "8")
            {
                string strLayerName;
                //C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
                strLayerName = stringArcValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringArcName == "10")
            {
                m_ptCenter.x = float.Parse(stringArcValue);
                return true;
            }
            else if (stringArcName == "20")
            {
                m_ptCenter.y = float.Parse(stringArcValue);
                return true;
            }
            else if (stringArcName == "40")
            {
                m_fRadium = float.Parse(stringArcValue);
                return true;
            }
            else if (stringArcName == "50")
            {
                m_fAngleStart = float.Parse(stringArcValue)/180.0f*DefineConstantsFdxf.PI;
                return true;
            }
            else if (stringArcName == "51")
            {
                m_fAngleEnd = float.Parse(stringArcValue) / 180.0f * DefineConstantsFdxf.PI;
                return true;
            }
            return true;
        }
        public bool AnalyseCircle(ref tagDXFSTRING strEntities)
        {
            string stringCircleName = strEntities.strCode;
            string stringCircleValue = strEntities.strValue;

            if (stringCircleName == "5" || stringCircleName == "330" || stringCircleName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringCircleName == "8")
            {
                string strLayerName;
                //C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
                strLayerName = stringCircleValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
            }
            else if (stringCircleName == "10")
            {
                m_ptCenter.x = float.Parse(stringCircleValue);
            }
            else if (stringCircleName == "20")
            {
                m_ptCenter.y = float.Parse(stringCircleValue);
            }
            else if (stringCircleName == "40")
            {
                m_fRadium = float.Parse(stringCircleValue);
            }
            return true;
        }
        public bool AnalyseRect(ref tagDXFSTRING strEntities)
        {
            return true;
        }
        ///////////////////////////////////////////////////////////////////////////////
        public bool AnalyseLwPolyLine(ref tagDXFSTRING strEntities)
        {
            string stringLwPolyLineName = strEntities.strCode;
            string stringLwPolyLineValue = strEntities.strValue;
            if (stringLwPolyLineName == "5" || stringLwPolyLineName == "330") //handle ,ignore
            {
                return true;
            }
            else if (stringLwPolyLineName == "8")
            {
                string strLayerName;
                strLayerName = stringLwPolyLineValue;

                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringLwPolyLineName == "90")
            {
                m_nLwPolyCount = Int32.Parse(stringLwPolyLineValue);
                return true;
            }
            else if (stringLwPolyLineName == "10")
            {
                m_ptTem.x = float.Parse(stringLwPolyLineValue);
                return true;
            }
            else if (stringLwPolyLineName == "20")
            {
                m_ptTem.y = float.Parse(stringLwPolyLineValue);

                if (m_nDxfCount == 0)
                {
                    m_nDxfCount++;
                    m_ptStart = m_ptTem;
                    m_ptPre = m_ptTem;
                    return true;
                }
                AddObjectWithUpAngle(m_pTemGroup, ref m_ptPre, ref m_ptTem, ref m_fUpAngle);
                m_fUpAngle = 0;
                m_nDxfCount++;
                m_ptPre = m_ptTem;
                return true;
            }
            else if (stringLwPolyLineName == "42" || stringLwPolyLineName == "43")
            {
                m_fUpAngle = float.Parse(stringLwPolyLineValue);
                if (m_fUpAngle > 0)
                {
                    m_nDirection = 1;
                }
                else if (m_fUpAngle < 0)
                {
                    m_nDirection = 2;
                }
                //绝对值
                m_fUpAngle = Math.Abs(m_fUpAngle);

                return true;
            }
            else if (stringLwPolyLineName == "70")
            {
                m_nClosed = Int32.Parse(stringLwPolyLineValue);
                return true;
            }
            return true;
        }
        public bool AnalysePolyLine(ref tagDXFSTRING strEntities)
        {
            string stringPolyLineName = strEntities.strCode;
            string stringPolyLineValue = strEntities.strValue;
            if (stringPolyLineName == "5" || stringPolyLineName == "330" || stringPolyLineName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringPolyLineName == "8")
            {
                string strLayerName;
                strLayerName = stringPolyLineValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringPolyLineName == "70")
            {
                m_nClosed = Int32.Parse(stringPolyLineValue);
                return true;
            }

            return true;
        }
        public bool AnalyseEllipse(ref tagDXFSTRING strEntities)
        {
            string stringEllipseName = strEntities.strCode;
            string stringEllipseValue = strEntities.strValue;

            if (stringEllipseName == "5" || stringEllipseName == "330" || stringEllipseName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringEllipseName == "8")
            {
                string strLayerName;
                strLayerName = stringEllipseValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringEllipseName == "10")
            {
                m_ptCenter.x = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "20")
            {
                m_ptCenter.y = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "11")
            {
                m_ptStart.x = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "21")
            {
                m_ptStart.y = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "40")
            {
                m_fEllipseRatio = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "41")
            {
                m_fAngleStart = float.Parse(stringEllipseValue);
            }
            else if (stringEllipseName == "42")
            {
                m_fAngleEnd = float.Parse(stringEllipseValue);
            }
            return true;
        }
        public bool AnalyseVertex(ref tagDXFSTRING strEntities)
        {
            string stringVertexName = strEntities.strCode;
            string stringVertexValue = strEntities.strValue;

            if (stringVertexName == "5" || stringVertexName == "330" || stringVertexName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringVertexName == "10")
            {
                m_ptTem.x = float.Parse(stringVertexValue);
                return true;
            }
            else if (stringVertexName == "20")
            {
                m_ptTem.y = float.Parse(stringVertexValue);
                if (m_bFlagPolyLineStart != 0)
                {
                    if (m_nDxfCount == 0)
                    { 
                        m_nDxfCount++;
                        m_ptStart = m_ptTem;
                        m_ptPre = m_ptTem;
                        return true;
                    }
                    if (m_nDxfCount++ >0)
                    {
                        AddObjectWithUpAngle(m_pTemGroup, ref m_ptPre, ref m_ptTem, ref m_fUpAngle);
                        m_fUpAngle = 0;
                    }                    
                    m_ptPre = m_ptTem;
                }
                //////////////////////////////
                return true;
            }
            else if (stringVertexName == "42")
            {
                m_fUpAngle = float.Parse(stringVertexValue);
                if (m_fUpAngle > 0)
                {
                    m_nDirection = 1;
                }
                else if (m_fUpAngle < 0)
                {
                    m_nDirection = 2;
                }
                m_fUpAngle = Math.Abs(m_fUpAngle);
                return true;
            }
            return true;
        }
        public bool AnalysePoint(ref tagDXFSTRING strEntities)
        {
            string stringPointName = strEntities.strCode;
            string stringPointValue = strEntities.strValue;

            if (stringPointName == "5" || stringPointName == "330" || stringPointName == "100") //handle ,ignore
            {
                return false;
            }
            else if (stringPointName == "8")
            {
                string strLayerName;
                strLayerName = stringPointValue;
                m_pCurrentLayer = SearchLayer(ref strLayerName);
                if (m_pCurrentLayer == null)
                {
                    m_pCurrentLayer = new CWhLayer();
                    m_pObjList.AddTail(m_pCurrentLayer);
                    m_pCurrentLayer.SetLayerName(strLayerName);
                }
                return true;
            }
            else if (stringPointName == "10")
            {
                m_ptTem.x = float.Parse(stringPointValue);
                return true;
            }
            else if (stringPointName == "20")
            {
                m_ptTem.y = float.Parse(stringPointValue);
                return true;
            }
            return true;
        }
        public CWhLayer SearchLayer(ref string strLayerName)
        {
            __POSITION posStart = m_pObjList.GetHeadPosition();
            CWhLayer pRtnLayer = null;
            while (posStart != null)
            {
                CWhVirtual pVirtual = (CWhVirtual)m_pObjList.GetNext(ref posStart);
                if (pVirtual.m_nObjType == DefineConstantsFdxf.WH_TYPE_LAYER)
                {
                    if (((CWhLayer)pVirtual).GetLayerName() == strLayerName)
                    {
                        pRtnLayer = (CWhLayer)pVirtual;
                        break;
                    }
                }
            }

            return pRtnLayer;
        }
        public tagUpPara GetArcUpPara(ref Point ptStart, ref Point ptEnd, ref double fUpAngle)
        {
            tagUpPara paraRtn = new tagUpPara();
            Point ptUpPoint = new Point();
            double fDistance = (ptStart.Distance(ptEnd) / 2)  *fUpAngle;
            int k = 0;
            ptUpPoint = GetUpPoint(ref ptStart, ref ptEnd, ref fDistance);


            Point[] ptTem = new Point[3];
            Point centerPoint = new Point();
            ptTem[0] = Point((int)ptStart.x, (int)ptStart.y);
            ptTem[1] = Point((int)ptEnd.x, (int)ptEnd.y);
            ptTem[2] = Point((int)ptUpPoint.x, (int)ptUpPoint.y);

            centerPoint = CalCenterPoint(ptTem[0], ptTem[1], ptTem[2]);

            paraRtn.centerPoint = new Point(centerPoint.x, centerPoint.y);
            paraRtn.fRadium = ptEnd.Distance(paraRtn.centerPoint);

            return paraRtn;
        }
        public Point GetUpPoint(ref Point ptStart, ref Point ptEnd, ref double fDistance)
        {
            Point ptRet = new Point();
            Point pt1 = new Point();
            Point pt2 = new Point();
            Point ptRelative1 = new Point();
            Point ptRelative2 = new Point();
            double k1 = 0.0;
            double b2 = 0.0;
            double a = 0.0;
            double b = 0.0;
            double c = 0.0;
            double fValue = 0.0;
            double detx = 0.0;
            double dety = 0.0;
            double addx = 0.0;
            double addy = 0.0;
            double m = 0.0;

            detx = ptEnd.x - ptStart.x;
            dety = ptEnd.y - ptStart.y;
            addx = ptEnd.x + ptStart.x;
            addy = ptStart.y + ptEnd.y;

            k1 = dety / detx;
            b2 = ((addy) + (1 / k1) * (addx)) / 2;
            m = (b2 - (addy) / 2);
            a = 1 / (k1 * k1) + 1;
            b = -(addx) - 2 * b2 / k1 + (addy) / k1;
            c = (addx) * (addx) / 4 + (m) * (m) - fDistance  *fDistance;



            if (ptStart.x == ptEnd.x)
            {
                pt1.x -= fDistance;
                pt1.y = (pt1.y + pt2.y) / 2;
                pt2.x += fDistance;
                pt2.y = pt1.y;
            }
            else
            {
                pt1.x = (-b + Math.Pow((b * b - 4 * a * c), 0.5)) / (2 * a);
                pt1.y = -1 / k1*(pt1.x) + b2;
                pt2.x = (-b - Math.Pow((b * b - 4 * a * c), 0.5)) / (2 * a);
                pt2.y = -1 / k1*(pt2.x) + b2;
            }
            ptRelative1 = pt1 - ptStart; ptRelative2 = ptEnd - ptStart;
            fValue = ptRelative1.x * ptRelative2.y - ptRelative1.y * ptRelative2.x;
            if (m_nDirection == 1)
            {
                if (fValue > 0)
                {
                    //C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
                    //ORIGINAL LINE: ptRet = pt1;
                    ptRet.CopyFrom(pt1);
                }
                else
                {
                    //C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
                    //ORIGINAL LINE: ptRet = pt2;
                    ptRet.CopyFrom(pt2);
                }
            }
            else if (m_nDirection == 2)
            {
                if (fValue < 0)
                {
                    //C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
                    //ORIGINAL LINE: ptRet = pt1;
                    ptRet.CopyFrom(pt1);
                }
                else
                {
                    //C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
                    //ORIGINAL LINE: ptRet = pt2;
                    ptRet.CopyFrom(pt2);
                }
            }

            return ptRet;
        }
        public void AddObject()
        {

            if (m_nTypeEntities == 1)
            {
                m_pTemLine = new CWhLine();
                m_pTemLine.SetStartPoint(m_ptStart);
                m_pTemLine.SetEndPoint(m_ptEnd);

                m_pTemLine.SetIsShow(1);
                m_pTemLine.SetPenWidth(0);
                //////
                m_pCurrentLayer.AddObject(m_pTemLine);
                m_pTemLine = null;

                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 2)
            {
                /////////////////////////////////////////////
                Rectangle rcBound = new Rectangle(Point((int)(m_ptCenter.x - m_fRadium), (int)(m_ptCenter.y + m_fRadium)), Point((int)(m_ptCenter.x + m_fRadium), (int)(m_ptCenter.y - m_fRadium)));
                Point ptStart = new Point(m_fRadium * Math.Cos(m_fAngleStart), m_fRadium * Math.Sin(m_fAngleStart));
                Point ptEnd = new Point(m_fRadium * Math.Cos(m_fAngleEnd), m_fRadium * Math.Sin(m_fAngleEnd));
                ptStart += m_ptCenter;
                ptEnd += m_ptCenter;

                m_pTemArc = new CWhArc(rcBound, ptStart, ptEnd, m_nDirection);
                Debug.Assert(m_pTemArc);
                m_pTemArc.SetDirection(1);

                m_pTemArc.SetIsShow(1);
                m_pTemArc.SetPenWidth(0);
                //////
                m_pCurrentLayer.AddObject(m_pTemArc);
                m_pTemArc = null;
                /////////////////////////////////////////////
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 3)
            {
                Rectangle rcBound = new Rectangle(Point((int)(m_ptCenter.x - m_fRadium), (int)(m_ptCenter.y + m_fRadium)), Point((int)(m_ptCenter.x + m_fRadium), (int)(m_ptCenter.y - m_fRadium)));
                m_pTemRect = new CWhEllipse(rcBound);

                //m_pTemRect->SetPenColor(COLORREF( RGB(255, 0, 0)));     //颜色设置
                m_pTemRect.SetIsShow(1);
                m_pTemRect.SetPenWidth(0);
                //////
                m_pCurrentLayer.AddObject(m_pTemRect);
                m_pTemRect = null;
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 4)
            {


                if (m_nClosed != 0)
                {
                    AddObjectWithUpAngle(m_pTemGroup, ref m_ptPre, ref m_ptStart, ref m_fUpAngle);
                    m_fUpAngle = 0;
                }
                m_pCurrentLayer.AddObject(m_pTemGroup);
                m_pTemGroup = null;
                m_nDxfCount = 0;
                m_nClosed = 0;
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 5)
            {
                if (m_bFlagPolyLineStart != 0)
                {

                }
                else
                {
                    //封口 wuhaodxf
                    if (m_nClosed != 0)
                    {
                        AddObjectWithUpAngle(m_pTemGroup, ref m_ptPre, ref m_ptStart, ref m_fUpAngle);
                        m_fUpAngle = 0;
                    }

                    m_pCurrentLayer.AddObject(m_pTemGroup);
                    m_pTemGroup = null;
                    m_nDxfCount = 0;
                }
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 6)
            {
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 7)
            {
                m_nTypeEntities = 0;
                return;
            }
            else if (m_nTypeEntities == 8)
            {
                m_nTypeEntities = 0;
                return;
            }

            return;
        }


        public void AddLastObject()
        {
            AddObject();
        }

        public void AddObjectWithUpAngle(CWhGroup pTemGroup, ref Point ptStart, ref Point ptEnd, ref double fUpAngle)
        {
            if (fUpAngle == 1)
            {
                Point centerPoint = new Point((ptStart.x + ptEnd.x) / 2, (ptStart.y + ptEnd.y) / 2);
                m_fRadium = (ptStart.Distance(ptEnd)) / 2.0;
                Rectangle rcBound = new Rectangle(Point((int)(centerPoint.x - m_fRadium), (int)(centerPoint.y + m_fRadium)), Point((int)(centerPoint.x + m_fRadium), (int)(centerPoint.y - m_fRadium)));
                m_pTemArc = new CWhArc(rcBound, ptStart, ptEnd, m_nDirection);
                Debug.Assert(m_pTemArc);
                m_pTemArc.SetDirection(m_nDirection);

                m_pTemArc.SetIsShow(1);
                m_pTemArc.SetPenWidth(0);
                pTemGroup.AddObject(m_pTemArc);
                m_pTemArc = null;
            }
            else if (fUpAngle == 0)
            {
                m_pTemLine = new CWhLine();
                m_pTemLine.SetStartPoint(ptStart);
                m_pTemLine.SetEndPoint(ptEnd);
                //m_pTemLine->SetPenColor(COLORREF( RGB(255, 0, 0)));     //颜色设置
                m_pTemLine.SetIsShow(1);
                m_pTemLine.SetPenWidth(0);
                m_pTemGroup.AddObject(m_pTemLine);
                m_pTemLine = null;
            }
            else
            { //一般情况
                tagUpPara upPara = GetArcUpPara(ref ptStart, ref ptEnd, ref fUpAngle);
                Point centerPoint = new Point(upPara.centerPoint);
                m_fRadium = upPara.fRadium;
                Rectangle rcBound = new Rectangle(Point((int)(centerPoint.x - m_fRadium), (int)(centerPoint.y + m_fRadium)), Point((int)(centerPoint.x + m_fRadium), (int)(centerPoint.y - m_fRadium)));
                m_pTemArc = new CWhArc(rcBound, ptStart, ptEnd, m_nDirection);
                Debug.Assert(m_pTemArc);
                m_pTemArc.SetDirection(m_nDirection);
                //m_pTemArc->SetPenColor(COLORREF( RGB(255, 0, 0)));     //颜色设置
                m_pTemArc.SetIsShow(1);
                m_pTemArc.SetPenWidth(0);
                pTemGroup.AddObject(m_pTemArc);
                m_pTemArc = null;
            }
        }

        public void SetRatio(int fRatio)
        {
            //	if( fRatio == 0 )
            //	{
            //       m_fDxfRatio = 1000  25.4;  //wuhao
            //	}
            //	else if( fRatio == 1 )
            //	{
            //       m_fDxfRatio = 1000  25.4;
            //	}
            //	else if( fRatio == 4 )
            //	{
            //       m_fDxfRatio = 1000;
            //	}
            //	else if( fRatio == 4 )
            //	{
            //       m_fDxfRatio = 1000;
            //	}
        }

        private CWhListContainer m_pObjList;
        private CWhLayer m_pCurrentLayer;
        private CWhGroup m_pTemGroup;

        private CWhLine m_pTemLine;
        private CWhArc m_pTemArc;
        private CWhEllipse m_pTemRect;

        private tagDXFSTRING m_strEntities = new tagDXFSTRING();
        private int m_bFlagPolyLineStart;
        private int m_nLwPolyCount;
        private int m_nTypeEntities;

        private double m_fDxfRatio;
        private Point m_ptTem = new Point();
        private Point m_ptPre = new Point();
        private Point m_ptStart = new Point();
        private Point m_ptEnd = new Point();
        private Point m_ptCenter = new Point();
        private double m_fRadium;
        private int m_nDirection;
        private int m_nDxfCount;
        private double m_fAngleStart;
        private double m_fAngleEnd;
        private double m_fUpAngle;
        private int m_nClosed;
        private double m_fEllipseRatio;

    }
    public class CWhDxfHeaders
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfHeaders()
        {
            m_nTypeHeaders = 0;
            m_nUnit = 0;
        }
        public virtual void Dispose()
        {

        }

        public void SetHeadersString(ref tagDXFSTRING strHeaders)
        {
            m_strHeaders.strCode = strHeaders.strCode;
            m_strHeaders.strValue = strHeaders.strValue;
        }
        public int JustifyHeadersType()
        {

            if (m_strHeaders.strCode == "9")
            {
                if (m_strHeaders.strValue == "$INSUNITS")
                {
                    m_nTypeHeaders = 1;
                    return DefineConstantsWhDxfHeaders.TRUE;
                }
                else if (m_strHeaders.strValue == "$ANGDIR")
                {
                    m_nTypeHeaders = 2;
                    return DefineConstantsWhDxfHeaders.TRUE;
                }
                else
                {
                    m_nTypeHeaders = 0;
                    return DefineConstantsWhDxfHeaders.TRUE;
                }
            }

            switch (m_nTypeHeaders)
            {
                case 1:
                    AnalyseRatio(ref m_strHeaders);
                    break;
                case 2:

                    break;
                case 3:

                    break;

            }

            return DefineConstantsWhDxfHeaders.TRUE;
        }
        public void AnalyseRatio(ref tagDXFSTRING strHeaders)
        {
            //C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
            //ORIGINAL LINE: string stringRatioName = strHeaders.strCode;
            string stringRatioName = new @string(strHeaders.strCode);
            //C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
            //ORIGINAL LINE: string stringRatioValue = strHeaders.strValue;
            string stringRatioValue = new @string(strHeaders.strValue);

            if (stringRatioName == "70")
            {
                //C++ TO C# CONVERTER TODO TASK: The c_str method is not converted to C#:
                m_nUnit = Convert.ToInt32(stringRatioValue.c_str());
            }
        }

        public int GetRatio()
        {
            return m_nUnit;
        }

        private tagDXFSTRING m_strHeaders = new tagDXFSTRING();
        private int m_nTypeHeaders;
        private int m_nUnit;

    }
    public class CWhDxfObjects
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfObjects()
        {

        }
        public virtual void Dispose()
        {

        }

    }
    public class CWhDxfParse
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfParse()
        {
            m_pImagicOblist = null;
            m_nFlagGroup = 0;
            m_bFlagSpaceLineCount = DefineConstantsWhDxfParse.FALSE;
            m_bFalgSectionStart = DefineConstantsWhDxfParse.FALSE;
            m_nSectionType = 0;
        }
        public virtual void Dispose()
        {

        }


        public void SetObjList(CWhListContainer pImagicOblist)
        {

            m_pImagicOblist = pImagicOblist;


        }
        public int SetString(ref string strDxfLine)
        {

            if ((strDxfLine == "") && (!m_bFlagSpaceLineCount) && (m_nFlagGroup))
            {
                m_bFlagSpaceLineCount = DefineConstantsWhDxfParse.TRUE;
            }
            else if ((strDxfLine == "") && (!m_nFlagGroup))
            {
                return 0;
            }

            if (m_nFlagGroup == 0)
            {
                m_strInput.strCode = strDxfLine;
                m_nFlagGroup++;
                m_bFlagSpaceLineCount = DefineConstantsWhDxfParse.FALSE;

                return 0;
            }
            else
            {
                m_strInput.strValue = strDxfLine;
                m_nFlagGroup = 0;

                return 1;
            }
        }
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        //	int JustifyGroupCode();
        public int JustifyMatch()
        {

            return DefineConstantsWhDxfParse.TRUE;
        }

        private CWhListContainer m_pImagicOblist;
        private tagDXFSTRING m_strInput = new tagDXFSTRING();
        private int m_nFlagGroup;
        private int m_bFlagSpaceLineCount;
        private int m_bFalgSectionStart;
        private int m_nSectionType;

        private CWhDxfHeaders m_DxfHeaders = new CWhDxfHeaders();
        private CWhDxfEntities m_DxfEntities = new CWhDxfEntities();
        private CWhDxfBlocks m_DxfBlocks = new CWhDxfBlocks();
        private CWhDxfObjects m_DxfObjects = new CWhDxfObjects();

    }
    public class CWhDxfTables
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfTables()
        {

        }
        public virtual void Dispose()
        {

        }

    }

    public class CWhDxfBlocks
    {

        //////////////////////////////////////////////////////////////////////
        // Construction/Destruction
        //////////////////////////////////////////////////////////////////////

        public CWhDxfBlocks()
        {

        }

    }

}