﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class Tilemap_generate : MonoBehaviour
{
	[SerializeField] public Tilemap layerGround;

  [SerializeField] Tile tile;
	[SerializeField] GameObject item;
  public int ch_tile = 0;
	public float item_spwn = 10;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public static int[,] GenerateArray(int width, int height, bool empty)
	{
		int[,] map = new int[width, height];
		for (int x = 0; x < map.GetUpperBound(0); x++)
		{
			for (int y = 0; y < map.GetUpperBound(1); y++)
			{
				if (empty)
				{
					map[x, y] = 0;
				}
				else
				{
					map[x, y] = 1;
				}
			}
		}
		return map;
	}


	public static void UpdateMap(int[,] map, Tilemap tilemap) //マップとタイルマップを取得し、null タイルを必要箇所に設定する
	{
		for (int x = 0; x < map.GetUpperBound(0); x++)
		{
			for (int y = 0; y < map.GetUpperBound(1); y++)
			{
				//再レンダリングではなく、マップの更新のみを行う
				//これは、それぞれのタイル（および衝突データ）を再描画するのに比べて
				//タイルを null に更新するほうが使用リソースが少なくて済むためです。
				if (map[x, y] == 0)
				{
					tilemap.SetTile(new Vector3Int(x, y, 0), null);
				}
			}
		}
	}
	public static void RenderMap(int[,] map, Tilemap tilemap,TileBase tile,GameObject item, float item_spwn)
	{
		bool is_item;
		//マップをクリアする（重複しないようにする）
		tilemap.ClearAllTiles();
		//マップの幅の分、周回する
		for (int x = 0; x < map.GetUpperBound(0); x++)
		{
			is_item = false;
			//マップの高さの分、周回する
			for (int y = 0; y < map.GetUpperBound(1); y++)
			{
				// 1 = タイルあり、0 = タイルなし
				if (map[x, y] == 1)
				{
					tilemap.SetTile(new Vector3Int(x, y, 0), tile);
				}
				else{
					if (x > 0 && x % item_spwn == 0 && !is_item){
						GameObject go = Instantiate(item,new Vector3Int(x, y, 0), Quaternion.identity);
						go.transform.position = tilemap.transform.position + new Vector3(x * 0.4f, y * 0.4f + 0.2f, 0);
						is_item = true;
					}
				}
			}
		}
	}
	public static int[,] RandomWalkTopSmoothed(int[,] map, int minSectionWidth, int rd)
	{

		//開始位置を特定する
		int lastHeight = Random.Range(0, map.GetUpperBound(1));

    int lastmax = 2;

		//どの方向に進むかの特定に使用される
		int nextMove = 0;
		//現在のセクション幅の把握に使用される
		int sectionWidth = 0;

		//配列の幅において処理を行う
		for (int x = 0; x <= map.GetUpperBound(0); x++)
		{
			//次の動きを特定する
			nextMove = Random.Range(0,8);
      if (lastHeight == -1 && sectionWidth > minSectionWidth){
      	lastHeight = lastmax;
      }
			//セクション幅の最小限の値より大きい現在の高さを使用した場合にのみ、高さを変更する
			if ((nextMove == 0 || nextMove == 3) && lastHeight > 0 && sectionWidth > minSectionWidth)
			{
				lastHeight -= Random.Range(1,rd);
				if (lastHeight < 2)
					lastHeight = Random.Range(1,4);
				sectionWidth = 0;
			}
			else if ((nextMove == 1 || nextMove == 2) && lastHeight < map.GetUpperBound(1) && sectionWidth > minSectionWidth)
			{
				lastHeight += Random.Range(1,rd);
				if (lastHeight > map.GetUpperBound(1))
					lastHeight = Random.Range(1,map.GetUpperBound(1));
				sectionWidth = 0;
			}
			else if (nextMove == 5 && sectionWidth > minSectionWidth)
			{
				lastmax = lastHeight;
				lastHeight = -1;
				sectionWidth = 3;
			}
			//セクション幅をインクリメントする
			sectionWidth++;
      for (int y = lastHeight; y >= 0; y--)
			{
				    map[x, y] = 1;
			}
		}
		return map;
	}

    public void Map_generator(int size, int min_sec, int rb){
        int[,] map = GenerateArray(size,30,true);
        //float map_x;
        map = RandomWalkTopSmoothed(map, min_sec, rb);
        RenderMap(map, layerGround, tile,item, item_spwn);
        //map_x = layerGround[ch_tile].gameObject.transform.position.x;
        //if (ch_tile == 0)
        //    ch_tile = 1;
        //else
        //    ch_tile = 0;
        //layerGround[ch_tile].transform.position += new Vector3(20, 0, 0);
        //return (map_x + 10);
    }
}