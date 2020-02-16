# Altseed2 Document

[Altseed2](https://github.com/altseed/altseed2-csharp)のドキュメント

# 生成に必要なもの

- Visual Studio
  - ほかのC#コンパイラでいけるかは不明
  - Homebrew で入れた Mono はダメとある。
- [DocFX](https://github.com/dotnet/docfx)
  - `choco install docfx` するか Release からバイナリを落として解凍し、パスを通す

# 生成

```
docfx metadata
docfx build
```

`docfx --serve` とするとリッチなページがみられる。（CORSに引っかからない）
