        protected override void OnAdded()
        {
            // プレイヤーを設定
+            player = new Player(this, new Vector2F(100, 360));
-            player = new Player(new Vector2F(100, 360));
        }

+       // エンジンから削除されたときに実行
+       protected override void OnRemoved()
+       {
+           // 衝突判定を全てリセット
+           CollidableObject.objects.Clear();
+       }
