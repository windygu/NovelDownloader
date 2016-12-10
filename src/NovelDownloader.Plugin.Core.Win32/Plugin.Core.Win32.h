#pragma once

#ifndef _PLUGIN_CORE_WIN32_H_
#define _PLUGIN_CORE_WIN32_H_

#include "exports.h"
#include "macros.h"
#include "Version.h"
#include <Windows.h>

struct PluginInterface_;
struct Plugin_;

#ifdef _NOVEL_DOWNLOAD_PLUGIN_H_
#ifdef __cplusplus
typedef struct NovelDownloadPlugin_ Plugin;
#else
typedef const struct NovelDownloadPluginInterface_ *Plugin;
#endif
#else
#ifdef _PLUGIN_H_
#ifdef __cplusplus
typedef struct Plugin_ Plugin;
#else
typedef const struct PluginInterface_ *Plugin;
#endif
#endif
#endif

#ifdef __cplusplus
EXTERN_C
{
#endif

typedef HANDLE HPLUGIN;

NOVELDOWNLOADERPLUGINCOREWIN32_API HPLUGIN LoadPlugin();
NOVELDOWNLOADERPLUGINCOREWIN32_API void ReleasePlugin(HPLUGIN);

#ifdef __cplusplus
}
#endif
#endif