import React, { lazy, Suspense } from 'react';

const LazyBooks = lazy(() => import('./Books'));

const Books = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode; }) => (
  <Suspense fallback={null}>
    <LazyBooks {...props} />
  </Suspense>
);

export default Books;
