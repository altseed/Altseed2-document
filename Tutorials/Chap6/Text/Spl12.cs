        // ショット
        private void Shot()
        {
            // Zキーでショットを放つ
            if (Engine.Keyboard.GetKeyState(Key.Z) == ButtonState.Push)
            {
+               Parent.AddChildNode(new PlayerBullet(mainNode, Position));
-               Parent.AddChildNode(new PlayerBullet(Position));
            }
        }
